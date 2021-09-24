import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserAuthenticateRequest } from '../model/user-authenticate-request.model';
import { Observable } from 'rxjs';
import { UserAuthenticateResponse } from '../model/user-authenticate-response.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) {
  }

  public PostAuthenticate(userAuthenticate: UserAuthenticateRequest) : Observable<UserAuthenticateResponse> {

    return this.httpClient.post<UserAuthenticateResponse>(`${environment.urlApi}/api/User/authenticate`, userAuthenticate);

  }

}
