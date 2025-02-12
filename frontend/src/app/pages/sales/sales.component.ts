import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { CommonModule } from '@angular/common'; 

@Component({
    selector: 'app-sales',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './sales.component.html',
    styleUrls: ['./sales.component.scss']
})
export class SalesComponent implements OnInit {
  sales: any[] = [];

  constructor(private apiService: ApiService) {}

  async ngOnInit() {
    try {
      const response = await this.apiService.getSales();
      this.sales = response.data;
    } catch (error) {
      console.error('Erro ao buscar vendas:', error);
    }
  }
}
