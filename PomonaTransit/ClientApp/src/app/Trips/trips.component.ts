import { Component, Inject, OnInit } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent implements OnInit {
  public trips: TripOffering[];

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.getTrips().subscribe(res => this.trips = res);
  }
  getTrips(): Observable<TripOffering[]> {
    return this.http.get<TripOffering[]>('api/TripOfferings')
  }
}

export class TripOffering {
  public date: Date;
  public driver: string;
  public id: number;
  public scheduledStartTime: Date;
  public secheduledArrivalTime: Date;
  public  trip: object;
}
