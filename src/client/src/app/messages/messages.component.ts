import { Component, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { PlyrComponent } from 'ngx-plyr';
import { ToastrService } from 'ngx-toastr';
import { Member } from '../_models/members';
import { Membership } from '../_models/membership';
import { Videolink, VideolinkToSend } from '../_models/vdeolink';
import { MembersService } from '../_services/members.service';
import { VideoService } from '../_services/video.service';
//import * as Plyr from 'plyr';


@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})

export class MessagesComponent implements OnInit {
  member: Member;
  allMemberships: Membership[];
  
  @ViewChild(PlyrComponent)
  plyr: PlyrComponent;

  links: Videolink[];
  linkToAdd: VideolinkToSend = {} as VideolinkToSend;
  nameToAdd: string;
  urlToAdd: string;
  selectedLink: Videolink = {} as Videolink;
  urlSafe: SafeResourceUrl;

  // or get it from plyrInit event 'https://cdn.plyr.io/static/demo/View_From_A_Blue_Moon_Trailer-576p.mp4'
  player: Plyr; 

  videoSources: Plyr.Source[] = [
    {
      src: 'https://youtu.be/_luhn7TLfWU',
      provider: 'youtube',
    }
  ];

  youtubeSources = [
    {
      src: 'https://youtube.com/watch?v=bTqVqk7FSmY',
      provider: 'youtube',
    },
  ];
  constructor(private memberService: MembersService, private videoService: VideoService, 
    private toastr: ToastrService, public sanitizer: DomSanitizer) {
      
  }

  ngOnInit(): void {  
    this.memberService.getMemberByToken().subscribe(member => {
      this.member = member;
      if(this.member.memberships.length > 0) {
        this.getLinks();      
      }
    })
    
  }

  getLinks() {
    this.videoService.getVideolinks().subscribe(links => {
      this.links = links;
      if (this.links.length > 0) {
        this.selectedLink = this.links[0];
      }
      else {
        this.selectedLink.link = "https://drive.google.com/file/d/1l4cqIcwEmDuSwHJWK7i-06RbjFr6fG1T/preview";
      }
      this.urlSafe = this.sanitizer.bypassSecurityTrustResourceUrl(this.selectedLink.link);
    });
  }

  onTypeAdd() {
    this.videoService.postVideolink(this.linkToAdd).subscribe(t => {
      this.toastr.success(`Видео добавлено`) ;
    }), (e => {
      console.log(e);  
    })
  }

  onSelected() {
    this.urlSafe = this.sanitizer.bypassSecurityTrustResourceUrl(this.selectedLink.link);
  }

  onAddLink() {
      if(this.urlToAdd.includes("view?usp=sharing")) {
      this.linkToAdd.link = this.urlToAdd.replace("view?usp=sharing", "preview");
      this.linkToAdd.name = this.nameToAdd;
      console.log(this.urlToAdd);
      this.videoService.postVideolink(this.linkToAdd).subscribe(l => {
        this.toastr.success(`Видео добавлено`) ;
        this.getLinks(); 
      }), (e => {
        console.log(e);  
      })
    }
  }

  onRemoveLink() {
    if(confirm("Are you sure to delete ")) {
      this.videoService.deleteVideolink(this.selectedLink.id).subscribe(d => {
        this.toastr.success("Видео удалено");
        this.getLinks(); 
      })
    }
    
  }

}
