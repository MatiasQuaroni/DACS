import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
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
        this.usersService
          .signIn(loginCredentials)
          .then((result) => {
            return UserActions.signInRequestSucceeded({
              userData: {
                id: result.user.uid,
                emailAddress: result.user.email,
              },
            });
          })
          .catch((error) => UserActions.signInRequestFailed({ error }))
      )
    )
  );

  signInRequestFailed$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(
          UserActions.signInRequestFailed,
          UserActions.signUpRequestFailed
        ),
        switchMap((action) => this.presentToast(action.error.message))
      ),
    { dispatch: false }
  );

  signInSucceeded$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(UserActions.signInRequestSucceeded),
        switchMap(() => this.router.navigate(['/roads/home']))
      ),
    { dispatch: false }
  );

  signOutRequested$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UserActions.signOutRequested),
      switchMap(() =>
        this.usersService.signOut().then(() => {
          return UserActions.signOutRequestSucceeded();
        })
      )
    )
  );

  signedOut$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(UserActions.signOutRequestSucceeded),
        switchMap(() => this.router.navigate(['/users/login']))
      ),
    { dispatch: false }
  );

  signUpRequested$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UserActions.signUpRequested),
      switchMap(({ emailAddress, password }) =>
        this.usersService
          .signUp(emailAddress, password)
          .then((result) => {
            return UserActions.signUpSucceeded({
              id: result.user.uid,
              email: result.user.email,
            });
          })
          .catch((error) => UserActions.signUpRequestFailed({ error }))
      )
    )
  );

  signUpSucceeded$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(UserActions.signUpSucceeded),
        switchMap(() => this.router.navigate(['/roads/home']))
      ),
    { dispatch: false }
  );

  async presentToast(message: any) {
    const toast = await this.toastController.create({
      message: message,
      duration: 2000,
      color: 'primary',
    });
    toast.present();
  }

  constructor(
    private actions$: Actions,
    private usersService: UsersService,
    private router: Router,
    private toastController: ToastController
  ) {}
}
