import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/services/base.service';
import { User } from '../models/user';
import { Observable, catchError, map } from 'rxjs';

@Injectable()
export class UserService extends BaseService {

  constructor(private http: HttpClient) { super() }

  createUser(user: User): Observable<User> {
    let response = this.http
      .post(this.UrlService + 'User', user, this.ObterAuthHeaderJson())
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));

    return response
  }
}
