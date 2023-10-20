
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../models/pagination';
import { Product } from '../models/product';
import { Brand } from '../models/brand';
import { Type } from '../models/type';
import { ShopParams } from '../models/shopParams';


@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  //getProducts(brandId?: number, typeId?: number, sort?: string) {
  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();
    // add a parameter has name "brandId" ,value "brandId"
    if (shopParams.brandId > 0) params = params.append('brandId', shopParams.brandId);
    if (shopParams.typeId) params = params.append('typeId', shopParams.typeId);
    //if (sort) params = params.append('sort', sort);
    params = params.append('sort', shopParams.sort);
    if (shopParams.pageNumber) params = params.append('pageIndex', shopParams.pageNumber);
    if (shopParams.pageSize) params = params.append('pageSize', shopParams.pageSize);
    if (shopParams.search) params = params.append('search', shopParams.search);

    // params.append('pageIndex', shopParams.pageNumber);
    // params.append('pageSize', shopParams.pageSize);
    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products',{params});
  }

  getBrands() {
    return this.http.get<Brand[]>(this.baseUrl + 'products/brands');
  }

  getTypes() {
    return this.http.get<Type[]>(this.baseUrl + 'products/types');
  }
}
