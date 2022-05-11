import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Membership } from '../_models/membership';
import { MembershipHistoryRecord } from '../_models/membershipHistoryRecord';
import { MembershipToSend } from '../_models/membershipToSend';
import { MembershipToUpdate } from '../_models/membershipToUpdate';
import { MembershipType } from '../_models/membershipType';
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

  getAllMemberships(memberId: number) {
    return this.http.get<Membership[]>(this.baseUrl + 'apiMembership/AllMemberships?clientId=' + memberId);
  }

  update(membership: MembershipToUpdate) {
    return this.http.put<MembershipToUpdate>(this.baseUrl + 'apiMembership/Update', membership).pipe();
  }

  updateType(embershipType: MembershipType) {
    return this.http.put<MembershipType>(this.baseUrl + 'apiMembership/UpdateType', embershipType).pipe();
  }

  addType(type: string) {
    return this.http.post<any>(this.baseUrl + 'apiMembership/AddType?membershipType=' + type, type).pipe();
  }

  addSize(count: number) {
    return this.http.post<any>(this.baseUrl + 'apiMembership/AddSize?membershipSize=' + count, count).pipe();
  }
   
}
