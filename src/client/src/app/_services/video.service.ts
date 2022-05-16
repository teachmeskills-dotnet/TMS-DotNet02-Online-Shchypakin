import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Videolink, VideolinkToSend } from '../_models/vdeolink';

@Injectable({
  providedIn: 'root'
})
export class VideoService {
  baseUrl = environment.apiUrl;
  
  constructor(private http: HttpClient) { }

  getVideolinks(){
    return this.http.get<Videolink[]>(this.baseUrl + 'apiVideolinks/GetAll');
  }

  postVideolink(record: VideolinkToSend) {
    return this.http.post<VideolinkToSend>(this.baseUrl + 'apiVideolinks/Add', record).pipe();
  }

  deleteVideolink(id: number) {
    return this.http.delete<Videolink>(this.baseUrl + 'apiVideolinks/delete/' + id).pipe();
  }

}
