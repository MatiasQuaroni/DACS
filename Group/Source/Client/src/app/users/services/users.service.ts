import { ThisReceiver } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { Action, Store } from '@ngrx/store';
import firebase from 'firebase/compat';
import { BehaviorSubject } from 'rxjs';
import { LoginModel, User } from '../+state/model';
import { UsersFacadeService } from './users-facade.service';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  public currentUser$: BehaviorSubject<User> = new BehaviorSubject<User>({
    id: null,
    username: null,
    emailAddress: null,
  });

  constructor(
    private fireAuth: AngularFireAuth,
    private fireStore: AngularFirestore,
    private usersFacade: UsersFacadeService
  ) {
    this.fireAuth.authState.subscribe((firebaseUser) => {
      this.configureAuthState(firebaseUser);
    });
  }
  configureAuthState(firebaseUser: firebase.User) {
    if (firebaseUser) {
      firebaseUser.getIdToken().then((newToken) => {
        console.log(newToken);
        localStorage.setItem('jwt', newToken);
      });
    }
  }

  public signIn(loginModel: LoginModel) {
    return this.fireAuth.signInWithEmailAndPassword(
      loginModel.email,
      loginModel.password
    );
  }

  public getToken() {
    return localStorage.getItem('jwt');
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
