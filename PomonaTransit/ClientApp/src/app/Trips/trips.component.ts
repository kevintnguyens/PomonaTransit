import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent implements OnInit {
  public trips: TripOffering[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<TripOffering[]>(baseUrl + 'api/Trips').subscribe(result => {
      this.trips = result;
    }, error => console.error(error));
  }

  ngOnInit() {
    console.log(this.trips);
  }

}


interface TripOffering {
  ID: number;
  TripNumber: number;
  Date: Date;
  ScheduledStartTime: Date;
  SecheduledArrivalTime: Date;
  Driver: string;
}
