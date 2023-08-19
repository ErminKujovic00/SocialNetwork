import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders} from '@angular/common/http'
import {Observable, of} from "rxjs";
import {Email} from '../data/Email';

@Injectable({
  providedIn: 'root'
})
export class EmailSenderService {

  url = 'https://localhost:7297/api/EmailSender';

  constructor(private http: HttpClient) { }

  postEmail(name: string, subject: string, email: string, message: string): Observable<Email>{
    const header = new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Access-Control-Allow-Origin', '*');
    const params = new HttpParams()
    .set('name', name)
    .set('subject', subject)
    .set('mail', email)
    .set('message', message);
    return this.http.post<Email>(this.url, {}, {'headers': header, params: params});
  }
}
