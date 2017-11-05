import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Course } from '../_models/index';
import { Observable } from 'rxjs/Observable';
import "rxjs/Rx";
import { CommonService } from '../../shared/common.service';
import { UserProfile } from '../user/user.profile'


@Injectable()
export class CourseService {

  
    public url = this.commonService.getBaseMasterUrl() + '/Course';
    public _saveUrl: string = '/Course/SaveContact/';
    //public _updateUrl: string = '/Course/UpdateContact/';
    //  public _deleteByIdUrl: string = this.commonService.getBaseUrl() + '/Course/';

    constructor(private http: Http, private commonService: CommonService, private authProfile: UserProfile) { }



    getCourses() {
        let url = this.commonService.getBaseMasterUrl() + '/course';
       let profile = this.authProfile.getProfile();
       let headers = new Headers({ 'Authorization': 'Bearer ' + profile.token });

        //var getCoursesUrl = this._getCoursesUrl;
        return this.http.get(url, { headers: headers })
            .map(response => <any>(<Response>response).json());
    }


    saveCourse(course: Course): Observable<string> {
        let body = JSON.stringify(course);
        let profile = this.authProfile.getProfile();
        let headers = new Headers({ 'Authorization': 'Bearer ' + profile.token , 'Content-Type': 'application/json', 'Accept': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.url, body, options)
            .map(res => res.json())
            .catch(this.handleError);
    }

    updateCourse(course: Course): Observable<string> {
        let body = JSON.stringify(course);
        let profile = this.authProfile.getProfile();
        let headers = new Headers({ 'Authorization': 'Bearer ' + profile.token , 'Content-Type': 'application/json', 'Accept': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.put(this.url + '/' + course.id , body, options)
            .map(res => res.json())
            .catch(this.handleError);
    }


    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Opps!! Server error');
    }
 
    //Delete Operation
    deleteCourse(id: number): Observable<string> {
        var deleteByIdUrl = this.url + '/' + id;
        let profile = this.authProfile.getProfile();
        let headers = new Headers({ 'Authorization': 'Bearer ' + profile.token, 'Content-Type': 'application/json', 'Accept': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.delete(deleteByIdUrl)
            .map(response => response.json())
            .catch(this.handleError);
    }

    //private handleError(error: Response) {
    //    return Observable.throw(error.json().error || 'Opps!! Server error');
    //}

}