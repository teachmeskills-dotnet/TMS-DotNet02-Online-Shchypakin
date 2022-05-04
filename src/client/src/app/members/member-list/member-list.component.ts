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
import { MembershipHistoryRecord } from 'src/app/_models/membershipHistoryRecord';
import { AlertComponent } from 'ngx-bootstrap/alert';
import { ToastrService } from 'ngx-toastr';
import { MembershipService } from 'src/app/_services/membership.service';
//import { Observable } from 'rxjs/internal/Observable';


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
  allMemberships: Membership[];
  membershypType: MembershipType;
  membershipSize: MembershipSize;
  membershipHistoryRecord: MembershipHistoryRecord;
  alerts: any[] = [{}];
  isCollapsed = true;
  private currentMemberSource = new ReplaySubject<Member>(1);
  currentMember$ = this.currentMemberSource.asObservable();
  


  constructor(private memberService: MembersService, private membershipService: MembershipService, 
    private toastr: ToastrService) { }

  ngOnInit(): void { 
    this.loadMembers();
    const member: Member = JSON.parse(localStorage.getItem('member'));
    
    if(member) {
      //this.selectedMember = member;
      this.setSelectedMember(member.id);
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
    this.setSelectedMember(this.getSelectedId());
  }

  setSelectedMember(id: number) {   
    this.memberService.getMemberById(id).subscribe(member => {
      this.selectedMember = member; 
      localStorage.setItem('member', JSON.stringify(member));
    });
  }

  getSelectedId(): number {
    const selectedName: string = this.myControl.value;
    return this.membersNames.find(option => option.fullName === selectedName).id;
  }


  registerVisit(membershipId: number) {
    const record :MembershipHistoryRecord = {} as MembershipHistoryRecord; 
    record.date = new Date();
    record.membershipId = membershipId;
    console.log(record);
    console.log(this.memberService);
    this.membershipService.postRecord(record).subscribe(r => {
      this.membershipHistoryRecord = r;    
      this.setSelectedMember(this.selectedMember.id);
      //this.fireVisitRegisterSuccess();
      this.toastr.success(`Посещение отмечено: ${new Date().toLocaleTimeString()}`) ;        
    })
  }

  deleteRecord(recordId: number) {
    this.membershipService.deleteRecord(recordId).subscribe(r =>{
      this.setSelectedMember(this.selectedMember.id);
    })
  }

  addMembership() {
    this.setSelectedMember(this.selectedMember.id);
  }

  onShowHistory(evt: any) {
    this.membershipService.getAllMemberships(this.selectedMember.id).subscribe(m => {
      this.allMemberships = m;
      //console.log(m);
    });
    console.log(evt);
  }


/*
  fireVisitRegisterSuccess(): void {
    this.alerts.push({
      type: 'success',
      msg: `Посещение отмечено: ${new Date().toLocaleTimeString()}`,
      timeout: 5000
    });
  }
*/
}
