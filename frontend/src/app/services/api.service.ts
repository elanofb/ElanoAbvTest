import { Injectable } from '@angular/core';
import axios from 'axios';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private BASE_URL = 'http://localhost:5119/api'; // Atualize com o URL correto

  async getUsers() {
    return axios.get(`${this.BASE_URL}/users`);
  }

  async getSales() {
    return axios.get(`${this.BASE_URL}/sales`);
  }

  async getProducts() {
    return axios.get(`${this.BASE_URL}/products`);
  }
}
