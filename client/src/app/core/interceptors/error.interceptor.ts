import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toast: ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((errorResponse: HttpErrorResponse) => {
        if (errorResponse) {
          if (errorResponse.status === 400) {
             if (errorResponse.error.errors) {
               //this.router.navigateByUrl('bad-request')
               throw errorResponse.error;
             } else {
              this.toast.error(errorResponse.error.message, errorResponse.status.toString())
             }
          }
          if (errorResponse.status === 401) {
            this.router.navigateByUrl('/unauthorized');
            //this.toast.error(error.error.message, error.status.toString())
          }
          if (errorResponse.status === 404) {
            this.router.navigateByUrl('/not-found');
            //this.router.navigateByUrl('/not-found');
          };
          if (errorResponse.status === 500) {
            //this.router.navigateByUrl('/server-error');
            const navigationExtras: NavigationExtras = {state: {error: errorResponse.error}};
            this.router.navigateByUrl('/server-error', navigationExtras);
          }
        }
        return throwError(() => new Error(errorResponse.message))
      })
    )
  }
}
