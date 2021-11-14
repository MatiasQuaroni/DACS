import { createAction, props } from '@ngrx/store';
import { LoginModel, User } from './model';

export const signInRequested = createAction(
  '[Users] Sign in requested',
  props<{
    loginCredentials: LoginModel;
  }>()
);

export const signInRequestSucceeded = createAction(
  '[Users] Sign in request succeeded',
  props<{ userData: User }>()
);
