import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MemberName } from '../_models/memberName';
import { Member } from '../_models/members';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user')).token
  })
}

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMembers() {
    return this.http.get<MemberName[]>(this.baseUrl + 'apiClients/ClientsNames', httpOptions);
  }

  getMemberById(id: number) {
    return this.http.get<Member>(this.baseUrl + 'apiClients/' + id, httpOptions);
  }
}
