import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { MemberName } from '../_models/memberName';
import { Member } from '../_models/members';
import { MembershipHistoryRecord } from '../_models/membershipHistoryRecord';

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

  postRecord(record: MembershipHistoryRecord) {
    //apiHistoryRecord/Add
    return this.http.post<MembershipHistoryRecord>(this.baseUrl + 'apiHistoryRecord/Add', record).pipe(
      
    );
  }

  deleteRecord(id: number) {
    return this.http.delete<MembershipHistoryRecord>(this.baseUrl + 'apiHistoryRecord/delete/' + id).pipe(

    );
  }
  
}
