import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IHero } from "../models/hero.interface";

@Injectable({
  providedIn: "root",
})
export class ApiService {
  constructor(private _http: HttpClient) {}

  getHeroes() {
    return this._http.get("http://localhost:4201/api/heroes");
  }

  evolve(hero: IHero)  {
    return this._http.post("http://localhost:4201/api/heroes?action=evolve", hero);
  }
}
