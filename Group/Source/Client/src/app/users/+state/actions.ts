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

export const signInRequestFailed = createAction(
  '[Users] Sign in request failed',
  props<{ error: any }>()
);

export const signOutRequested = createAction('[Users] Sign out requested');

export const signOutRequestSucceeded = createAction('[Users] Signed out');

export const signUpRequested = createAction(
  '[Users] Sign up requested',
  props<{ emailAddress: string; password: string }>()
);

export const signUpSucceeded = createAction(
  '[Users] Sign up succeeded',
  props<{
    id: string;
    email: string;
  }>()
);

export const signUpRequestFailed = createAction(
  '[Users] Sign up request failed',
  props<{ error: any }>()
);

export const registerUserRequested = createAction(
  '[Users] User registration requested',
  props<{
    id: string;
    email: string;
  }>()
);

export const userRegistrationSucceeded = createAction(
  '[Users] User registration succeeded'
);
