import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserEditDataComponent } from 'src/app/user/user-edit-data/user-edit-data.component';
import { Member } from 'src/app/_models/members';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-profile',
  templateUrl: './member-profile.component.html',
  styleUrls: ['./member-profile.component.css']
})
export class MemberProfileComponent implements OnInit {
  member: Member;
  constructor(private memberService: MembersService, 
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

  onUpdateClick() {
    console.log("on update");
    const ref = this.modalService.open(UserEditDataComponent, { centered: true });
    ref.componentInstance.user = this.member;
  }
 
}
