import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MemberName } from '../_models/memberName';
import { Member } from '../_models/members';
import { MembershipHistoryRecord } from '../_models/membershipHistoryRecord';
import { MemberToSend } from '../_models/memberToSend';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;
  private currentMemberSource = new ReplaySubject<Member>(1);
  currentMember$ = this.currentMemberSource.asObservable();

  constructor(private http: HttpClient) { }

  getMembers() {
    return this.http.get<MemberName[]>(this.baseUrl + 'apiClients/ClientsNames');
  }

  getMemberById(id: number) {
    return this.http.get<Member>(this.baseUrl + 'apiClients/' + id);
  }


  putMember(member: MemberToSend) {
    return this.http.put<MemberToSend>(this.baseUrl + 'apiClients/' + member.id,  member).pipe();
  }
  
  getMemberByToken() {
    return this.http.get<Member>(this.baseUrl + 'apiClients/profile');
  }
}
