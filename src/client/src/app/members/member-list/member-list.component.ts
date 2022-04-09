import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, ReplaySubject } from 'rxjs';
import { MemberName } from 'src/app/_models/memberName';
import { MembersService } from 'src/app/_services/members.service';
import { map, startWith } from 'rxjs/operators';
import { Member } from 'src/app/_models/members';
import { Membership } from 'src/app/_models/membership';
import { MembershipType } from 'src/app/_models/membershipType';
import { MembershipSize } from 'src/app/_models/membershipSize';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  membersNames: MemberName[];
  name: MemberName;
  myControl = new FormControl();
  autoFilter: Observable<string[]>;
  selectedMember: Member;
  membership: Membership;
  membershypType: MembershipType;
  membershipSize: MembershipSize;
  
  constructor(private memberService: MembersService) { }

  ngOnInit(): void { 
    this.loadMembers();
    const member: Member = JSON.parse(localStorage.getItem('member'));
    if(member) {
      this.selectedMember = member;
    }  
  }

  private mat_filter(value: string): string[] {                                            //.indexOf(filterValue) === 0);
    const filterValue = value.toLowerCase();                                               //.includes(filterValue));
    return this.membersNames.map(name => name.fullName).filter(option => option.toLowerCase().indexOf(filterValue) === 0);
  }  

  loadMembers() {
    this.memberService.getMembers().subscribe(members => {
      this.membersNames = members;
    })
  }

  onInputClick() {
    this.autoFilter = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this.mat_filter(value))
    ); 
  }

  displayFn(memberName: MemberName) {
    return memberName ? memberName.fullName : undefined;
  }

  onShowClick() {
    this.getSelectedId();
    this.memberService.getMemberById(this.getSelectedId()).subscribe(member => {
      this.selectedMember = member; 
      localStorage.setItem('member', JSON.stringify(member));
    });
  }

  getSelectedId(): number {
    const selectedName: string = this.myControl.value;
    return this.membersNames.find(option => option.fullName === selectedName).id;
  }

  testClick() {
    console.log(this.selectedMember);
  }

}
