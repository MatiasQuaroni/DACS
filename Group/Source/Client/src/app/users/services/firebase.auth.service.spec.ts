import { TestBed } from '@angular/core/testing';

import { FirebaseAuthService } from './firebase.auth.service';

describe('Firebase.AuthService', () => {
  let service: FirebaseAuthService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FirebaseAuthService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});