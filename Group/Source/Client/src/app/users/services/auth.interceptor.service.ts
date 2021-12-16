import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UsersService } from './users.service';

@Injectable({
  providedIn: 'root',
})
export class AuthInterceptor implements HttpInterceptor {
  constructor(private auth: UsersService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = this.auth.getToken();
    console.log(token);
    if (token) {
      var header = 'Bearer ' + token;
      var reqWithAuth = req.clone({
        headers: req.headers.set('Authorization', header),
      });
      return next.handle(reqWithAuth);
    }

    return next.handle(req);
  }
}
