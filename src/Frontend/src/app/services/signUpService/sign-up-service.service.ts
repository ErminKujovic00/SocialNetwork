import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { User } from 'src/app/data/UserSignUp';
import axios, { AxiosResponse } from 'axios';

@Injectable({
  providedIn: 'root'
})
export class SignUpService {

  constructor(private http: HttpClient) { }

  url = 'https://localhost:7297/api/Users';


  signUpUser(firstName: string, lastName: string, username: string, email: string, password: string): Promise<AxiosResponse<any>>{
    const header = new HttpHeaders().set('content-type', 'application/json').set('Access-Control-Allow-Origin', '*');
    console.log(firstName + lastName + username + email + password);

    const user: User = {
      firstName: firstName,
      lastName: lastName,
      username: username,
      userEmail: email,
      password: password
    };

    return axios.post(this.url, user, {
        headers: {
          "Content-Type": "application/json", // Set the content type to JSON
        },
      });
      /*.then((response) => {
        console.log("Sign up completed!");
        //console.log("Response data:", response.data);
      })
      .catch((error) => {
        console.error("Error:", error);
      });*/

    //const params = new HttpParams().set('firstName', firstName).set('lastName', lastName).set('username', username).set('userEmail', email).set('password', password);
    //console.log(JSON.stringify(user));
    //return this.http.post(this.url, JSON.stringify(user), {'headers': header/*, params: params, observe: 'response'*/});
  }
}
