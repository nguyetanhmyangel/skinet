import { ShopParams } from './../models/shopParams';

import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { Product } from '../models/product';
import { Brand } from '../models/brand';
import { Type } from '../models/type';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  products: Product[] = [];
  brands: Brand[] = [];
  types: Type[] = [];
  // brandIdSelected = 0;
  // typeIdSelected = 0;
  // sortSelected = 'name';
  shopParams = new ShopParams();
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to hight', value: 'priceAsc' },
    { name: 'Price: Hight to low', value: 'priceDesc' },
  ];
  totalCount = 0;

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    //this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected, this.sortSelected).subscribe({
    this.shopService.getProducts(this.shopParams).subscribe({
      next: (response) => {
          this.products = response.data
          this.shopParams.pageNumber = response.pageIndex,
          this.shopParams.pageSize = response.pageSize,
          this.totalCount = response.count
      },
      error: (error) => console.log(error),
    });
  }

  getBrands() {
    this.shopService.getBrands().subscribe({
      next: (response) => (this.brands = [{ id: 0, name: 'All' }, ...response]),
      error: (error) => console.log(error),
    });
  }

  getTypes() {
    this.shopService.getTypes().subscribe({
      next: (response) => (this.types = [{ id: 0, name: 'All' }, ...response]),
      error: (error) => console.log(error),
    });
  }

  onBrandSelected(brandId: number) {
    //this.brandIdSelected = brandId;
    this.shopParams.brandId = brandId;
    this.getProducts();
  }

  onTypeSelected(typeId: number) {
    //this.typeIdSelected = typeId;
    this.shopParams.typeId = typeId;
    this.getProducts();
  }

  onSortSelected(event: any) {
    //this.sortSelected = event.target.value;
    this.shopParams.sort = event.target.value;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }
}
