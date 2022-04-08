import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MemberName } from 'src/app/_models/memberName';
import { MembersService } from 'src/app/_services/members.service';
import { map, startWith } from 'rxjs/operators';

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
  //Items: string[] = ['BoJack Horseman', 'Stranger Things', 'Ozark', 'Big Mouth'];

  constructor(private memberService: MembersService) { }

  ngOnInit(): void { 
    this.loadMembers();
    
  }

  private mat_filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.membersNames.map(name => name.fullName).filter(option => option.toLowerCase().includes(filterValue));
    //return this.Items.filter(option => option.toLowerCase().includes(filterValue));
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

}
