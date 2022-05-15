import { Component, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { PlyrComponent } from 'ngx-plyr';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/members';
import { Membership } from 'src/app/_models/membership';
import { Videolink, VideolinkToSend } from 'src/app/_models/vdeolink';
import { MembersService } from 'src/app/_services/members.service';
import { VideoService } from 'src/app/_services/video.service';


@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.css']
})
export class VideoComponent implements OnInit {
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


  constructor(private memberService: MembersService, private videoService: VideoService, 
    private toastr: ToastrService, public sanitizer: DomSanitizer) { }

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
