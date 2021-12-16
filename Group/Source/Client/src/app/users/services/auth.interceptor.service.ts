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
      var header =
        'Bearer ' +
        'eyJhbGciOiJSUzI1NiIsImtpZCI6Ijk1NmMwNDEwZmE1MjFjMTZlNDQ2NWE4ZjVjODU5NjZhNWY1MDk5NGIiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20vcm9hZHMtMTkxMmUiLCJhdWQiOiJyb2Fkcy0xOTEyZSIsImF1dGhfdGltZSI6MTYzOTYxMjQ0NCwidXNlcl9pZCI6IlVGM2piTHd2YkJhZmtRQktaUnBBNnFYUWZ1SjMiLCJzdWIiOiJVRjNqYkx3dmJCYWZrUUJLWlJwQTZxWFFmdUozIiwiaWF0IjoxNjM5NjEyNDQ0LCJleHAiOjE2Mzk2MTYwNDQsImVtYWlsIjoiYWRtaW5AZ21haWwuY29tIiwiZW1haWxfdmVyaWZpZWQiOmZhbHNlLCJmaXJlYmFzZSI6eyJpZGVudGl0aWVzIjp7ImVtYWlsIjpbImFkbWluQGdtYWlsLmNvbSJdfSwic2lnbl9pbl9wcm92aWRlciI6InBhc3N3b3JkIn19.ePhNi4TD-yH1Wkmk9qUnMrKwoIwh6BgSmwxn0y54fk3lDl4HETJMKM9QPj8rwrwDDS906yFY2NWU76seckIViQGRAU4ZIHbb1Rjk6GAg2EnwFhT0gLtgWX4Trrr4M0bwa_2Vg0g5d7tCSTDL-LJDdv6dFPvlYDmAxtv1ZI8213FjFVF6ucTEOSt1sIl57EPgielqRo8FEZ__prbCFf42rNfFvEUXMXvoqDYs5hqXiqzh6vdreAC7kPVxjnAzKZOAFRP9o0-nXDpma3nrDYkCkXIvx2yGceaaCjQ29oJ1wRog6NX3QFF6CYF1-2yTP0UaqM4kOkr_GtQZteHKJVtJwQ';
      var reqWithAuth = req.clone({
        headers: req.headers.set('Authorization', header),
      });
      return next.handle(reqWithAuth);
    }

    return next.handle(req);
  }
}
