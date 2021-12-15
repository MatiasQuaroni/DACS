import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { Action, Store } from '@ngrx/store';
import { LoginModel, User } from '../+state/model';
import { UsersFacadeService } from './users-facade.service';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  constructor(
    private fireAuth: AngularFireAuth,
    private fireStore: AngularFirestore,
    private usersFacade: UsersFacadeService
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

  public signOut() {
    return this.fireAuth.signOut();
  }
}
