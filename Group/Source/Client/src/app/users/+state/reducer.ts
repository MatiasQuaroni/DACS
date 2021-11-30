import { Action, createReducer, on } from '@ngrx/store';
import { User } from './model';
import * as UserActions from './actions';

export const usersFeatureKey = 'users';

export interface State {
  currentUser?: User;
  loading: boolean;
}

export const initialState: State = {
  loading: false,
};

const usersReducer = createReducer(
  initialState,
  on(UserActions.signInRequested, (state) => ({
    ...state,
    loading: true,
  })),
  on(UserActions.signInRequestSucceeded, (state, action) => ({
    ...state,
    currentUser: action.userData,
    loading: false,
  })),
  on(UserActions.signOutRequested, (state) => ({
    ...state,
    loading: true,
  })),
  on(UserActions.signOutRequestSucceeded, (state) => ({
    ...state,
    currentUser: null,
    loading: false,
  }))
);

export function reducer(state: State | undefined, action: Action) {
  return usersReducer(state, action);
}
