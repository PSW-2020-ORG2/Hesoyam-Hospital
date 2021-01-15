import { TenderOfferListing } from "./tender-offer-listing.model";

export class TenderOffer {
    Id:number;
    TenderId:number;
    PharmacyName:string;
    Email:string;
    TenderOfferListings:TenderOfferListing[];
}
