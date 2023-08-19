import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders, HttpErrorResponse} from '@angular/common/http'
import {Observable, of, throwError } from "rxjs";
import {Email} from '../../data/Email';
import { catchError } from 'rxjs/operators'



@Injectable({
  providedIn: 'root'
})
export class EmailSenderService {

  url = 'https://localhost:7297/api/EmailSender';

  constructor(private http: HttpClient) { }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);

    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }

  postEmail(name: string, subject: string, email: string, message: string){//: Observable<Email>{
    const header = new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Access-Control-Allow-Origin', '*');
    const params = new HttpParams()
    .set('name', name)
    .set('subject', subject)
    .set('mail', email)
    .set('message', message);
    //return this.http.post<Email>(this.url, {}, {'headers': header, params: params});
    return this.http.post(this.url, {}, {'headers': header, params: params, observe: 'response'});/*.pipe(
      catchError(this.handleError)
    );*/
  }
}
