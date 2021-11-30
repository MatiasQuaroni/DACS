export interface User {
  id: string;
  username?: string;
  emailAddress: string;
  claims?: any;
}

export interface LoginModel {
  email: string;
  password: string;
}
