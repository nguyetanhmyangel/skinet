
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../share/models/product';
import { Pagination } from '../share/models/pagination';
import { Brand } from '../share/models/brand';
import { Type } from '../share/models/type';


@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getProducts(brandId?: number, typeId?: number, sort?: string ) {
    let params = new HttpParams();
    // add a parameter has name "brandId" ,value "brandId"
    if (brandId) params = params.append('brandId', brandId);
    if (typeId) params = params.append('typeId', typeId);
    if (sort) params = params.append('sort', sort);
    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products',{params});
  }

  getBrands() {
    return this.http.get<Brand[]>(this.baseUrl + 'products/brands');
  }

  getTypes() {
    return this.http.get<Type[]>(this.baseUrl + 'products/types');
  }
}
