import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { Action, Store } from '@ngrx/store';
import { LoginModel, User } from '../+state/model';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  constructor(
    private fireAuth: AngularFireAuth,
    private fireStore: AngularFirestore,
    private store$: Store
  ) {}

  public signIn(loginModel: LoginModel) {
    return this.fireAuth.signInWithEmailAndPassword(
      loginModel.email,
      loginModel.password
    );
  }

  public signUp(email: string, password: string) {
    return this.fireAuth.createUserWithEmailAndPassword(email, password);
  }

  public saveUser(userModel: User) {
    return this.fireStore.collection('users').doc(userModel.id).set(userModel);
  }

  public isAuthenticated() {
    return true;
  }
}
