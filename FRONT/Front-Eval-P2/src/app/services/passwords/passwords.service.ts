import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs';
import {Password} from '../../models/password';

@Injectable({
  providedIn: 'root'
})
export class PasswordsService {

  private url : string = 'https://localhost:7237/api/Passwords';

  constructor(private httpClient : HttpClient) { }

  getPasswords() {
    return this.httpClient.get<any[]>(this.url)
      .pipe(
        map(data => data.map(password => new Password(
          password.id,
          password.username,
          password.content,
          password.application
        )))
      );
  }

  createPassword(password : any) {
    return this.httpClient.post<any>(this.url, password, {
      headers: {
        'Content-Type': 'application/json',
      }
    });
  }

  deletePassword(id : number) {
    return this.httpClient.delete<any>(this.url + '/' + id);
  }

  getPasswordById(id : number) {
    return this.httpClient.get<any>(this.url + '/' + id)
      .pipe(
        map(password => new Password(
          password.id,
          password.username,
          password.content,
          password.application
        ))
      )
  }
}
