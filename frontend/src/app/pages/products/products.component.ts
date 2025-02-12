import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { CommonModule } from '@angular/common'; 

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  products: any[] = [];

  constructor(private apiService: ApiService) {}

  async ngOnInit() {
    try {
      const response = await this.apiService.getProducts();
      this.products = response.data;
    } catch (error) {
      console.error('Erro ao buscar produtos:', error);
    }
  }
}
