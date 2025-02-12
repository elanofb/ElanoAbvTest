import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-users',
  standalone: true, // Se estiver usando Standalone Components
  imports: [CommonModule], // Adicionando CommonModule
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  users: any[] = [];

  constructor(private apiService: ApiService) {}

  async ngOnInit() {
    try {
      const response = await this.apiService.getUsers();
      this.users = response.data;
    } catch (error) {
      console.error('Erro ao buscar usuários:', error);
    }
  }
}
