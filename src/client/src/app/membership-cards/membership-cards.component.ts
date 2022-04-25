import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';

import { Membership } from '../_models/membership';
import { MembershipHistoryRecord } from '../_models/membershipHistoryRecord';
import { MembersService } from '../_services/members.service';
import {of} from 'rxjs';

@Component({
  selector: 'app-membership-cards',
  templateUrl: './membership-cards.component.html',
  styleUrls: ['./membership-cards.component.css']
})
export class MembershipCardsComponent implements OnInit {
@Input() membership: Membership;
@Input() id: number;
@Input() callbackFunction: (id: number, memberService: MembersService) => void;
@Input() memberService: MembersService;
@Output() parentFun: EventEmitter<number> = new EventEmitter();
@Output() parentRemoveFun: EventEmitter<number> = new EventEmitter();

records$: Observable<MembershipHistoryRecord[]>;

isCollapsed = true;

  constructor() { }

  ngOnInit(): void {
    /*if(this.membership.membershipHistoryRecords) {
      
      this.records$ = Observable.create((observer: Subscriber<any>) => {
        observer.next(this.membership.membershipHistoryRecords);
        observer.complete();
      });
    }*/
    this.records$ = this.getRecords(this.membership.membershipHistoryRecords)
  }

  getRecords(records: MembershipHistoryRecord[]) {
    if(records != null) 
    {
        return of(records);
    } 
  }

  onAddClick() {
    this.parentFun.emit(this.membership.id);
  }

  onRemoveClick(id: number) {
    this.parentRemoveFun.emit(id);
    console.log(id);
  }

}
