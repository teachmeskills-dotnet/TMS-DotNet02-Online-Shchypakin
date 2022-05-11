import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserEditDataComponent } from 'src/app/user/user-edit-data/user-edit-data.component';

import { Member } from 'src/app/_models/members';
import { Membership } from 'src/app/_models/membership';
import { MembersService } from 'src/app/_services/members.service';
import { MembershipService } from 'src/app/_services/membership.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  member: Member;
  allMemberships: Membership[];
  
  constructor(private memberService: MembersService, 
    private membershipService: MembershipService, 
    private route: ActivatedRoute,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.loadMember();
  }
 
  loadMember() {
    const id: number =  + this.route.snapshot.paramMap.get('id');
    
    this.memberService.getMemberByToken().subscribe(member => {
      this.member = member;
      console.log(this.member.fullName);
    })
  }

  onShowHistory(evt: any) {
    this.membershipService.getAllMemberships(this.member.id).subscribe(m => {
      this.allMemberships = m;
      //console.log(m);
    });
    console.log(evt);
  }
}
