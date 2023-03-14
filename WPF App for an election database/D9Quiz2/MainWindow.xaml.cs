using Election;
using Election.DBContext;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace D9Quiz2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
/// 


public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    ElectionContext db = new();

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        if (!db.Provinces.Any())
        {
            Debug.WriteLine("no data, creating data");

            List<Province> pro = new()
            {

                new Province {ProvinceName="Quebec", ShortCode = "QC" },
                new Province {ProvinceName="Manitoba", ShortCode = "MB" },
                new Province {ProvinceName="Ontario", ShortCode = "ON" },

            };

            db.Provinces.AddRange(pro);
            db.SaveChanges();
        }

        if (!db.Ridings.Any())
        {
            Debug.WriteLine("no data, creating data");

            var pro1 = db.Provinces.Where(P => P.ProvinceName == "Quebec").ToList()[0];
            var r1 = new Riding() { RidingName = "Kitchener-Conestoga", Province = pro1 };
            db.Ridings.AddRange(r1);

            var pro2 = db.Provinces.Where(P => P.ProvinceName == "Manitoba").ToList()[0];
            var r2 = new Riding() { RidingName = "Oakville", Province = pro2 };
            db.Ridings.AddRange(r2);

            var pro3 = db.Provinces.Where(P => P.ProvinceName == "Ontario").ToList()[0];
            var r3 = new Riding() { RidingName = "Niagara Falls", Province = pro3 };
            db.Ridings.AddRange(r3);

            db.SaveChanges();
        }

        if (!db.Parties.Any())
        {
            Debug.WriteLine("no data, creating data");

            List<Party> pt = new()
            {

                new Party {PartyName="Liberal Party", PartyWebsite="https://liberal.ca/", PartyEmail="assistance@liberal.ca"},
                new Party {PartyName="Bloc Québécois", PartyWebsite="https://www.blocquebecois.org/", PartyEmail="bloc@quebecois.ca"},
                new Party {PartyName="Conservative Party", PartyWebsite="https://www.conservative.ca/", PartyEmail="assistance@conservative.ca"},

            };

            db.Parties.AddRange(pt);
            db.SaveChanges();
        }

        if (!db.Candidates.Any())
        {
            Debug.WriteLine("no data, creating data");

            var pt1 = db.Parties.Where(P => P.PartyName == "Liberal Party").ToList()[0];
            var rd1 = db.Ridings.Where(r => r.RidingName == "Kitchener-Conestoga").ToList()[0];

            var c1 = new Candidate() { First = "Moon", Last = "Jeong", Website = "https://moonjeong.ca/", Email = "moonjeong@gmail.com", Party = pt1, Riding = rd1 };
            db.Candidates.AddRange(c1);

            var rd2 = db.Ridings.Where(r => r.RidingName == "Oakville").ToList()[0];
            var c2 = new Candidate() { First = "Tony", Last = "Johnson", Website = "https://tonyjohnson.ca/", Email = "tonyjohnson@hotmail.com", Party = pt1, Riding = rd2 };
            db.Candidates.AddRange(c2);

            var pt3 = db.Parties.Where(P => P.PartyName == "Bloc Québécois").ToList()[0];
            var rd3 = db.Ridings.Where(r => r.RidingName == "Niagara Falls").ToList()[0];

            var c3 = new Candidate() { First = "John", Last = "Bobason", Website = "https://johnbobason.ca/", Email = "johnbobason@hotmail.com", Party = pt3, Riding = rd3 };
            db.Candidates.AddRange(c3);

            var pt4 = db.Parties.Where(P => P.PartyName == "Conservative Party").ToList()[0];
            var c4 = new Candidate() { First = "Bob", Last = "Doody", Website = "https://bobdoody.ca/", Email = "bobdoody@gmail.com", Party = pt4, Riding = rd2 };
            db.Candidates.AddRange(c4);

            db.SaveChanges();
        }

        if (!db.Votes.Any())
        {
            Debug.WriteLine("no data, creating data");

            var c1 = db.Candidates.Where(c => c.First == "Moon").ToList()[0];
            var v1 = new Vote() { CastTime = Convert.ToDateTime("2022-06-23 11:30:20"), Candidate = c1 };
            db.Votes.Add(v1);

            var v2 = new Vote() { CastTime = Convert.ToDateTime("2022-06-22 09:22:20"), Candidate = c1 };
            db.Votes.Add(v2);

            var c3 = db.Candidates.Where(c => c.First == "Tony").ToList()[0];
            var v3 = new Vote() { CastTime = Convert.ToDateTime("2022-06-21 19:12:20"), Candidate = c3 };
            db.Votes.Add(v3);

            var c4 = db.Candidates.Where(c => c.First == "John").ToList()[0];
            var v4 = new Vote() { CastTime = Convert.ToDateTime("2022-06-22 13:44:10"), Candidate = c4 };
            db.Votes.Add(v4);

            var c5 = db.Candidates.Where(c => c.First == "Bob").ToList()[0];
            var v5 = new Vote() { CastTime = Convert.ToDateTime("2022-06-23 15:21:55"), Candidate = c5 };
            db.Votes.Add(v5);

            db.SaveChanges();
        }

        var candidates = db.Candidates.ToList();

        lvcand.ItemsSource = candidates;

    }
}
