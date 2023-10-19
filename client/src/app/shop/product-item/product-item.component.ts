import { Component, Input } from '@angular/core';
import { Product } from 'src/app/models/product';
// import { Product } from 'src/app/share/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent {
  @Input() product?: Product
}
