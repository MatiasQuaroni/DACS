import { createFeatureSelector, createSelector } from '@ngrx/store';
import { usersFeatureKey } from './reducer';
import * as fromUsers from './reducer';

export const selectUserState =
  createFeatureSelector<fromUsers.State>(usersFeatureKey);

export const selectCurrentUser$ = createSelector(
  selectUserState,
  (state) => state.currentUser
);

export const selectUsersLoading$ = createSelector(
  selectUserState,
  (state) => state.loading
);
