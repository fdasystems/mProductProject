import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http'  //, HttpResponse
import { MessageModel } from './../models/message.model';
import { stringify } from 'querystring';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private urlService='api/Contact';
  constructor(private http: HttpClient) { }

  SendMessageFromModel(messageToSend: MessageModel) {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {      To: messageToSend.To,
                      Subject: messageToSend.Subject,
                      Body: messageToSend.Body
              }
    
    return this.http.post < MessageModel > (this.urlService, body, {headers})
  }

  SendSimpleMessage(subject:string, bodyMessage:string) {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
        To: `${environment.contactTo}` , //  from config... messageToSend.To,
        Subject: subject, // messageToSend.Subject,
        Body: bodyMessage //messageToSend.Body
    }
       return this.http.post<MessageModel>(this.urlService, body, {headers});
  }

}