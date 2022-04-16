import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Membership } from '../_models/membership';
import { MembershipHistoryRecord } from '../_models/membershipHistoryRecord';
import { MembershipToSend } from '../_models/membershipToSend';
import { MembershipTypeSize } from '../_models/membershipTypeSize';

@Injectable({
  providedIn: 'root'
})
export class MembershipService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTypeSize(){
    return this.http.get<MembershipTypeSize>(this.baseUrl + 'apiMembership/SizeType');
  }

  deleteRecord(id: number) {
    return this.http.delete<MembershipHistoryRecord>(this.baseUrl + 'apiHistoryRecord/delete/' + id).pipe(
    );
  }

  postRecord(record: MembershipHistoryRecord) {
    return this.http.post<MembershipHistoryRecord>(this.baseUrl + 'apiHistoryRecord/Add', record).pipe();
  }

  postMembership(membership: MembershipToSend) {
    return this.http.post<MembershipToSend>(this.baseUrl + 'apiMembership/Add', membership).pipe();
  }

  
}
