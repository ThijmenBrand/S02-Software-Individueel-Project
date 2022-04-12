export default interface UserShape {
  userId: number;
  userName: string;
  userEmail: string;
  token: string;
}

export class User implements UserShape {
  userId: number;
  userEmail: string;
  userName: string;
  token: string;
  constructor(opts: UserShape) {
    this.userId = opts.userId;
    this.userEmail = opts.userEmail;
    this.userName = opts.userName;
    this.token = opts.token;
  }
}

export interface creds {
  email: string;
  password: string;
}
