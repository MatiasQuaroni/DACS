import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { switchMap } from 'rxjs/operators';
import { UsersService } from '../services/users.service';
import * as UserActions from './actions';

@Injectable()
export class UsersEffects {
  signInRequested$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UserActions.signInRequested),
      switchMap(({ loginCredentials }) =>
        this.usersService.signIn(loginCredentials).then((result) => {
          return UserActions.signInRequestSucceeded({
            userData: {
              id: result.user.uid,
              username: result.user.displayName,
              emailAddress: result.user.email,
            },
          });
        })
      )
    )
  );

  constructor(private actions$: Actions, private usersService: UsersService) {}
}
