import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';

import { Membership } from '../_models/membership';
import { MembershipHistoryRecord } from '../_models/membershipHistoryRecord';
import { MembersService } from '../_services/members.service';
import {of} from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EditMembershipComponent } from '../edit-membership/edit-membership.component';

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
@Input() editable: boolean;
isActive: boolean;
bgColor: any;

records$: Observable<MembershipHistoryRecord[]>;

isCollapsed = true;

  constructor(private modalService: NgbModal) { }

  ngOnInit(): void {
    this.records$ = this.getRecords(this.membership.membershipHistoryRecords);
    this.isActive = this.membership.end > new Date();
    if (this.membership.end > new Date()) {
      this.bgColor = 'bg-light';
    }
    else {
      this.bgColor = 'bg-dark';
    }
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

  onUpdateClick() {
    const ref = this.modalService.open(EditMembershipComponent, { centered: true });
    ref.componentInstance.selectedMembership = this.membership;
  }

}
