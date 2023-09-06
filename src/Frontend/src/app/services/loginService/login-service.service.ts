import { Injectable } from '@angular/core';
import axios, {AxiosResponse} from 'axios';

@Injectable({
  providedIn: 'root'
})
export class LoginService{

  url = 'https://localhost:7297/api/Authentication/login';

  constructor() { }

  
  userLogin(email: string, password: string): Promise<AxiosResponse<any>>{
    const user = {
      userEmail: email,
      password: password
    }
    return axios.post(this.url, user, {
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      }
    });
  }
}
