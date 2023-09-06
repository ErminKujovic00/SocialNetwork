import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private cookieService: CookieService) { }

  getTokenExpiry(token: string): Date{
    // Decode the JWT
    const decodedToken: any = jwt_decode(token);

    // Access the expiration (expiry) date from the decoded token
    const expirationDateInSeconds = decodedToken.exp;

    // Convert the expiration date to a JavaScript Date object
    const expirationDate = new Date(expirationDateInSeconds * 1000); // Multiply by 1000 to convert from seconds to milliseconds

    // You can now use the expirationDate as needed
    console.log('Token Expiration Date:', expirationDate);

    return expirationDate;
  }

  setToken(token: string){
    const expirationDate = this.getTokenExpiry(token);
    // Set the cookie with options for security
    //ako odjednom prestane radit istekao je token
    this.cookieService.set('bearerToken', token, expirationDate, '/', '', true, 'Lax'); //mozda treba promijenit ovaj domain i path odakle je accessible bearer
  }

  getToken(): string | undefined{
    return this.cookieService.get('bearerToken');
  }

  isExpired(){
    //treba napraviti funkciju koja provjeri da li je istekao token i traziti ponovni login
  }

  clearToken(){
    this.cookieService.delete('bearerToken');
  }

  // Method to check if the user is logged in
  isAuthenticated(): boolean {
    const token = this.getToken();
    if(token == null) return false;
    
    // GEt the expiration date 
    const isExpired = this.getTokenExpiry(token);

    // Get the current timestamp in seconds
    const currentDate = new Date();

    // Compare the expiration timestamp with the current timestamp
    if (isExpired < currentDate) {
      // The token has expired
      return false;
    } else {
      // The token is still valid
      return true;
    }
  }
}
