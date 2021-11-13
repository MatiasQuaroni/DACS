import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { LoginModel, UserModel } from '../login/models';

@Injectable({
  providedIn: 'root',
})
export class FirebaseAuthService {
  constructor(
    private fireAuth: AngularFireAuth,
    private fireStore: AngularFirestore
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

  public saveUser(userModel: UserModel) {
    return this.fireStore.collection('users').doc(userModel.id).set(userModel);
  }
}
