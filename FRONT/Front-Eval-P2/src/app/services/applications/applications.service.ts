import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Application} from '../../models/application';
import {map} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApplicationsService {

  private url : string = 'https://localhost:7237/api/Applications';

  constructor(private httpClient : HttpClient) { }

  getApplications() {
    return this.httpClient.get<any[]>(this.url).pipe(
      map(data => data.map(app => new Application(
        app.id,
        app.name,
        app.type
      )))
    );
  }

  createApplication(application : Application) {
    return this.httpClient.post<Application>(this.url, application, {
      headers: {
        'Content-Type': 'application/json',
      }
    });
  }
}
