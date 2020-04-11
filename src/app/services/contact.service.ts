import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http'  //, HttpResponse
import { MessageModel } from './../models/message.model';
import { stringify } from 'querystring';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  // private baseUrl='https://webapimpp.azurewebsites.net/';   private baseUrl='http://localhost:61504/';this.baseUrl+
  private urlService='api/Contact';


  constructor(private http: HttpClient) { }

  senddata(user: MessageModel) //any
  {
  /*  const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'  // o multipart/form-data , 'Authorization': 'my-auth-token'
    })};*/
  const body = JSON.stringify(user);
  const header = new HttpHeaders();
  header.append("Content-Type","application/json");
  //return this.http.post(this.urlService, body ,{ headers: header }).map((data: Response) => data.json() );
  }


  SendMessageFromModel(messageToSend: MessageModel) {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {      To: messageToSend.To,
                      Subject: messageToSend.Subject,
                      Body: messageToSend.Body
              }
    
    return this.http.post < MessageModel > (this.urlService, body, {headers})
  }

  SendSimpleMessage(subject:string, bodyMessage:string) {
    /*const messageToSend: new MessageModel( // messageToSend={};
    {
    To="fdasystems@gmail.com", //or from config...
    Subject=subject,
    Body=bodyMessage
    })   */

    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
        To:  "fdasystems@gmail.com", //or from config... messageToSend.To,
        Subject: subject, // messageToSend.Subject,
        Body: bodyMessage //messageToSend.Body
    }
       return this.http.post<MessageModel>(this.urlService, body, {headers});
   //  return this.http.post<any>(this.urlService, body, {headers});
  }

}