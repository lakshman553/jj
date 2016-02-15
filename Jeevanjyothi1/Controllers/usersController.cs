﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Jeevanjyothi1.Models;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Web.Configuration;

namespace Jeevanjyothi1.Controllers
{
    public class usersController : ApiController
    {
        private jeevanjyothi_dbEntities db = new jeevanjyothi_dbEntities();

        
        
        // GET: api/users
        public IQueryable<user> Getusers()
        {
            return db.users;
        }

        // GET: api/users/5
        [ResponseType(typeof(user))]
        public IHttpActionResult Getuser(int id)
        {
            user user = db.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putuser(int id, user user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("getusers/")]
        [HttpGet]
        public dynamic getDonorsList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var abc = db.vdonorslists.ToList();
            return new { data = abc };
        }

        [Route("pass/{id}/{oldPass}/{newPass}")]
        [HttpGet]
        public int chngPass(int id, string oldPass, string newPass)
        {
            db.Configuration.ProxyCreationEnabled = false;
            oldPass = Encrypt(oldPass);

            if (db.users.Count(recordset => recordset.id == id && recordset.password.Equals(oldPass))  == 0) {
                return 0;
            }
            else
            {
                user user = db.users.Find(id);
                user.password = Encrypt(newPass);
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;  
                return db.SaveChanges();
            }
        }
        [Route("updateProfile/")]
        [HttpPost]

        public int updateProfile (userProfile userProfile)
        {
            user user = db.users.Find(userProfile.userId);

            user.address1 = userProfile.address1;
            user.address2 = userProfile.address2;
            user.city = userProfile.city;
            user.state = userProfile.state;

            db.Entry(user).State = EntityState.Modified;

            return db.SaveChanges();


        }

        [Route("resetpass/{mobileNo}")]
        [HttpGet]
        public int resetPass(long mobileNo)
        {
            db.Configuration.ProxyCreationEnabled = false;
        
            string[] passwordStrings = { "aahs", "aals", "abas", "abba", "abbe", "abed", "abet", "able", "ably", "abos", "abri", "abut", "abye", "abys", "aced", "aces", "ache", "achy", "acid", "acme", "acne", "acre", "acta", "acts", "acyl", "adds", "adit", "ados", "adze", "aeon", "aero", "aery", "afar", "agar", "agas", "aged", "agee", "ager", "ages", "agha", "agin", "agio", "agly", "agma", "agog", "agon", "ague", "ahed", "ahem", "ahis", "ahoy", "aide", "aids", "ails", "aims", "ains", "airn", "airs", "airt", "airy", "aits", "ajar", "ajee", "akee", "akin", "alae", "alan", "alar", "alas", "alba", "albs", "alec", "alee", "alef", "ales", "alfa", "alga", "alif", "alit", "alky", "alls", "ally", "alma", "alme", "alms", "aloe", "alow", "alps", "also", "alto", "alts", "alum", "amah", "amas", "ambo", "amen", "amia", "amid", "amie", "amin", "amir", "amis", "ammo", "amok", "amps", "amus", "amyl", "anal", "anas", "ands", "anes", "anew", "anga", "anil", "anis", "ankh", "anna", "anoa", "anon", "ansa", "anta", "ante", "anti", "ants", "anus", "aped", "aper", "apes", "apex", "apod", "apos", "apps", "apse", "aqua", "arak", "arbs", "arch", "arco", "arcs", "area", "ares", "arfs", "aria", "arid", "aril", "arks", "arms", "army", "arse", "arts", "arty", "arum", "arvo", "aryl", "asci", "asea", "ashy", "asks", "asps", "atap", "ates", "atma", "atom", "atop", "auks", "auld", "aunt", "aura", "auto", "aver", "aves", "avid", "avos", "avow", "away", "awed", "awee", "awes", "awls", "awns", "awny", "awol", "awry", "axal", "axed", "axel", "axes", "axil", "axis", "axle", "axon", "ayah", "ayes", "ayin", "azan", "azon", "baal", "baas", "baba", "babe", "babu", "baby", "bach", "back", "bade", "bads", "baff", "bags", "baht", "bail", "bait", "bake", "bald", "bale", "balk", "ball", "balm", "bals", "bams", "band", "bane", "bang", "bani", "bank", "bans", "baps", "barb", "bard", "bare", "barf", "bark", "barm", "barn", "bars", "base", "bash", "bask", "bass", "bast", "bate", "bath", "bats", "batt", "baud", "bawd", "bawl", "bays", "bead", "beak", "beam", "bean", "bear", "beat", "beau", "beck", "beds", "bedu", "beef", "been", "beep", "beer", "bees", "beet", "begs", "bell", "bels", "belt", "bema", "bend", "bene", "bens", "bent", "berg", "berk", "berm", "best", "beta", "beth", "bets", "bevy", "beys", "bhut", "bias", "bibb", "bibs", "bice", "bide", "bidi", "bids", "bier", "biff", "bigs", "bike", "bile", "bilk", "bill", "bima", "bind", "bine", "bins", "bint", "biog", "bios", "bird", "birk", "birl", "biro", "birr", "bise", "bisk", "bite", "bits", "bitt", "bize", "blab", "blae", "blah", "blam", "blat", "blaw", "bleb", "bled", "blet", "blew", "blin", "blip", "blob", "bloc", "blog", "blot", "blow", "blub", "blue", "blur", "boar", "boas", "boat", "bobs", "bock", "bode", "bods", "body", "boff", "bogs", "bogy", "boho", "boil", "bola", "bold", "bole", "boll", "bolo", "bolt", "bomb", "bond", "bone", "bong", "bonk", "bony", "boob", "book", "boom", "boon", "boor", "boos", "boot", "bops", "bora", "bore", "bork", "born", "bort", "bosh", "bosk", "boss", "bota", "both", "bots", "bott", "bout", "bowl", "bows", "boxy", "boyo", "boys", "bozo", "brad", "brae", "brag", "bran", "bras", "brat", "braw", "bray", "bred", "bree", "bren", "brew", "brie", "brig", "brim", "brin", "brio", "bris", "brit", "broo", "bros", "brow", "brrr", "brut", "brux", "bubo", "bubs", "bubu", "buck", "buds", "buff", "bugs", "buhl", "buhr", "bulb", "bulk", "bull", "bumf", "bump", "bums", "buna", "bund", "bung", "bunk", "bunn", "buns", "bunt", "buoy", "bura", "burb", "burd", "burg", "burl", "burn", "burp", "burr", "burs", "bury", "bush", "busk", "buss", "bust", "busy", "bute", "buts", "butt", "buys", "buzz", "byes", "byre", "byrl", "byte", "cabs", "caca", "cade", "cadi", "cads", "cafe", "caff", "cage", "cagy", "caid", "cain", "cake", "caky", "calf", "calk", "call", "calm", "calo", "calx", "came", "camo", "camp", "cams", "cane", "cans", "cant", "cape", "caph", "capo", "caps", "carb", "card", "care", "cark", "carl", "carn", "carp", "carr", "cars", "cart", "casa", "case", "cash", "cask", "cast", "cate", "cats", "caul", "cave", "cavy", "caws", "cays", "ceca", "cede", "cedi", "cees", "ceil", "cell", "cels", "celt", "cent", "cepe", "ceps", "cere", "cero", "cess", "cete", "chad", "chai", "cham", "chao", "chap", "char", "chat", "chaw", "chay", "chef", "chew", "chez", "chia", "chic", "chid", "chin", "chip", "chis", "chit", "chon", "chop", "chow", "chub", "chug", "chum", "ciao", "cigs", "cine", "cion", "cire", "cist", "cite", "city", "clad", "clag", "clam", "clan", "clap", "claw", "clay", "clef", "clew", "clip", "clod", "clog", "clon", "clop", "clot", "cloy", "club", "clue", "coal", "coat", "coax", "cobb", "cobs", "coca", "cock", "coco", "coda", "code", "cods", "coed", "coff", "coft", "cogs", "coho", "coif", "coil", "coin", "coir", "coke", "coky", "cola", "cold", "cole", "cols", "colt", "coly", "coma", "comb", "come", "comp", "cone", "coni", "conk", "conn", "cons", "cony", "coof", "cook", "cool", "coon", "coop", "coos", "coot", "cope", "cops", "copy", "cord", "core", "corf", "cork", "corm", "corn", "cors", "cory", "cosh", "coss", "cost", "cosy", "cote", "cots", "coup", "cove", "cowl", "cows", "cowy", "coxa", "coys", "cozy", "crab", "crag", "cram", "crap", "craw", "cred", "crew", "crib", "cris", "crit", "croc", "crop", "crow", "crud", "crus", "crux", "cube", "cubs", "cuds", "cued", "cues", "cuff", "cuif", "cuke", "cull", "culm", "cult", "cunt", "cups", "curb", "curd", "cure", "curf", "curl", "curn", "curr", "curs", "curt", "cusk", "cusp", "cuss", "cute", "cuts", "cwms", "cyan", "cyma", "cyme", "cyst", "czar", "dabs", "dace", "dada", "dado", "dads", "daff", "daft", "dago", "dags", "dahl", "dahs", "dais", "daks", "dale", "dals", "dame", "damn", "damp", "dams", "dang", "dank", "dans", "daps", "darb", "dare", "dark", "darn", "dart", "dash", "data", "date", "dato", "daub", "daut", "davy", "dawk", "dawn", "daws", "dawt", "days", "daze", "dead", "deaf", "deal", "dean", "dear", "debs", "debt", "deck", "deco", "deed", "deem", "deep", "deer", "dees", "deet", "defi", "deft", "defy", "deil", "deke", "dele", "delf", "deli", "dell", "dels", "delt", "deme", "demo", "demy", "dene", "deni", "dens", "dent", "deny", "dere", "derm", "desk", "deva", "devs", "dews", "dewy", "dexy", "deys", "dhak", "dhal", "dhow", "dial", "dibs", "dice", "dick", "dido", "didy", "died", "diel", "dies", "diet", "diff", "difs", "digs", "dike", "dill", "dime", "dims", "dine", "ding", "dink", "dino", "dins", "dint", "diol", "dips", "dipt", "dire", "dirk", "dirl", "dirt", "disc", "dish", "disk", "diss", "dita", "dite", "dits", "ditz", "diva", "dive", "djin", "doat", "doby", "dock", "docs", "dodo", "doer", "does", "doff", "doge", "dogs", "dogy", "doit", "dojo", "dole", "doll", "dols", "dolt", "dome", "doms", "dona", "done", "dong", "dons", "doom", "door", "dopa", "dope", "dopy", "dore", "dork", "dorm", "dorp", "dorr", "dors", "dory", "dose", "doss", "dost", "dote", "doth", "dots", "doty", "doum", "dour", "doux", "dove", "down", "dows", "doxy", "doze", "dozy", "drab", "drag", "dram", "drat", "draw", "dray", "dree", "dreg", "drek", "drew", "drib", "drip", "drop", "drub", "drug", "drum", "drys", "duad", "dual", "dubs", "duce", "duci", "duck", "duct", "dude", "duds", "duel", "dues", "duet", "duff", "dugs", "duit", "duke", "dull", "duly", "duma", "dumb", "dump", "dune", "dung", "dunk", "duns", "dunt", "duos", "dupe", "dups", "dura", "dure", "durn", "duro", "durr", "dusk", "dust", "duty", "dyad", "dyed", "dyer", "dyes", "dyke", "dyne", "each", "earl", "earn", "ears", "ease", "east", "easy", "eath", "eats", "eaux", "eave", "ebbs", "ebon", "eche", "echo", "echt", "ecru", "ecus", "eddo", "eddy", "edge", "edgy", "edhs", "edit", "eels", "eely", "eery", "effs", "efts", "egad", "egal", "eger", "eggs", "eggy", "egis", "egos", "eide", "eked", "ekes", "elan", "elds", "elhi", "elks", "ells", "elms", "elmy", "else", "emes", "emeu", "emic", "emir", "emit", "emmy", "emus", "emyd", "ends", "engs", "enol", "enow", "enuf", "envy", "eons", "epee", "epha", "epic", "epos", "eras", "ergo", "ergs", "erne", "erns", "eros", "errs", "erst", "eses", "esne", "espy", "etas", "etch", "eths", "etic", "etna", "etui", "euro", "even", "ever", "eves", "evil", "ewer", "ewes", "exam", "exec", "exed", "exes", "exit", "exon", "expo", "eyas", "eyed", "eyen", "eyer", "eyes", "eyne", "eyra", "eyre", "eyry", "fabs", "face", "fact", "fade", "fado", "fads", "fags", "fail", "fain", "fair", "fake", "fall", "falx", "fame", "fane", "fang", "fano", "fans", "fard", "fare", "farl", "farm", "faro", "fart", "fash", "fast", "fate", "fats", "faun", "faux", "fava", "fave", "fawn", "fays", "faze", "feal", "fear", "feat", "feck", "feds", "feeb", "feed", "feel", "fees", "feet", "fehs", "fell", "felt", "feme", "fems", "fend", "fens", "feod", "fere", "fern", "fess", "fest", "feta", "fete", "fets", "feud", "feus", "fiar", "fiat", "fibs", "fice", "fico", "fido", "fids", "fief", "fife", "figs", "fila", "file", "fill", "film", "filo", "fils", "find", "fine", "fink", "fino", "fins", "fire", "firm", "firn", "firs", "fisc", "fish", "fist", "fits", "five", "fixt", "fizz", "flab", "flag", "flak", "flam", "flan", "flap", "flat", "flaw", "flax", "flay", "flea", "fled", "flee", "flew", "flex", "fley", "flic", "flip", "flir", "flit", "floc", "floe", "flog", "flop", "flow", "flub", "flue", "flus", "flux", "foal", "foam", "fobs", "foci", "foes", "fogs", "fogy", "fohn", "foil", "foin", "fold", "folk", "fond", "fons", "font", "food", "fool", "foot", "fops", "fora", "forb", "ford", "fore", "fork", "form", "fort", "foss", "foul", "four", "fowl", "foxy", "foys", "fozy", "frae", "frag", "frap", "frat", "fray", "free", "fret", "frig", "frit", "friz", "froe", "frog", "from", "frow", "frug", "fubs", "fuci", "fuck", "fuds", "fuel", "fugs", "fugu", "fuji", "full", "fume", "fumy", "fund", "funk", "funs", "furl", "furs", "fury", "fuse", "fuss", "futz", "fuze", "fuzz", "fyce", "fyke", "gabs", "gaby", "gadi", "gads", "gaed", "gaen", "gaes", "gaff", "gaga", "gage", "gags", "gain", "gait", "gala", "gale", "gall", "gals", "gama", "gamb", "game", "gamp", "gams", "gamy", "gane", "gang", "gaol", "gape", "gaps", "gapy", "garb", "gars", "gash", "gasp", "gast", "gate", "gats", "gaud", "gaum", "gaun", "gaur", "gave", "gawk", "gawp", "gays", "gaze", "gear", "geck", "geds", "geed", "geek", "gees", "geez", "geld", "gels", "gelt", "gems", "gene", "gens", "gent", "genu", "germ", "gest", "geta", "gets", "geum", "ghat", "ghee", "ghis", "gibe", "gibs", "gids", "gied", "gien", "gies", "gift", "giga", "gigs", "gild", "gill", "gilt", "gimp", "gink", "gins", "gips", "gird", "girl", "girn", "giro", "girt", "gist", "gite", "gits", "give", "glad", "glam", "gled", "glee", "gleg", "glen", "gley", "glia", "glib", "glim", "glob", "glom", "glop", "glow", "glue", "glug", "glum", "glut", "gnar", "gnat", "gnaw", "gnus", "goad", "goal", "goas", "goat", "gobo", "gobs", "goby", "gods", "goer", "goes", "gogo", "gold", "golf", "gone", "gong", "good", "goof", "gook", "goon", "goop", "goos", "gore", "gorm", "gorp", "gory", "gosh", "goth", "gout", "gowd", "gowk", "gown", "goys", "grab", "grad", "gram", "gran", "grat", "gray", "gree", "grew", "grey", "grid", "grig", "grim", "grin", "grip", "grit", "grog", "grok", "grot", "grow", "grub", "grue", "grum", "guan", "guar", "guck", "gude", "guff", "guid", "gulf", "gull", "gulp", "guls", "gums", "gunk", "guns", "guru", "gush", "gust", "guts", "guvs", "guys", "gybe", "gyms", "gyps", "gyre", "gyri", "gyro", "gyve", "haaf", "haar", "habu", "hack", "hade", "hadj", "haed", "haem", "haen", "haes", "haet", "haft", "hags", "haha", "hahs", "haik", "hail", "hair", "haji", "hajj", "hake", "haku", "hale", "half", "hall", "halm", "halo", "halt", "hame", "hams", "hand", "hang", "hank", "hant", "haps", "hard", "hare", "hark", "harl", "harm", "harp", "hart", "hash", "hasp", "hast", "hate", "hath", "hats", "haul", "haut", "have", "hawk", "haws", "hays", "haze", "hazy", "head", "heal", "heap", "hear", "heat", "hebe", "heck", "heed", "heel", "heft", "hehs", "heil", "heir", "held", "hell", "helm", "helo", "help", "heme", "hemp", "hems", "hens", "hent", "herb", "herd", "here", "herl", "herm", "hern", "hero", "hers", "hest", "heth", "hets", "hewn", "hews", "hick", "hide", "hied", "hies", "high", "hike", "hila", "hili", "hill", "hilt", "hims", "hind", "hins", "hint", "hips", "hire", "hisn", "hiss", "hist", "hits", "hive", "hoar", "hoax", "hobo", "hobs", "hock", "hods", "hoed", "hoer", "hoes", "hogg", "hogs", "hoke", "hold", "hole", "holk", "holm", "holp", "hols", "holt", "holy", "home", "homo", "homy", "hone", "hong", "honk", "hons", "hood", "hoof", "hook", "hoop", "hoot", "hope", "hops", "hora", "horn", "hose", "host", "hots", "hour", "hove", "howe", "howf", "howk", "howl", "hows", "hoya", "hoys", "hubs", "huck", "hued", "hues", "huff", "huge", "hugs", "huic", "hula", "hulk", "hull", "hump", "hums", "hung", "hunh", "hunk", "huns", "hunt", "hurl", "hurt", "hush", "husk", "huts", "hwan", "hyla", "hymn", "hype", "hypo", "hyps", "hyte", "iamb", "ibex", "ibis", "iced", "ices", "ichs", "icky", "icon", "idea", "idem", "ides", "idle", "idly", "idol", "idyl", "iffy", "iggs", "iglu", "ikat", "ikon", "ilea", "ilex", "ilia", "ilka", "ilks", "ills", "illy", "imam", "imid", "immy", "impi", "imps", "inby", "inch", "info", "inia", "inks", "inky", "inly", "inns", "inro", "inti", "into", "ions", "iota", "ired", "ires", "irid", "iris", "irks", "iron", "isba", "isle", "isms", "itch", "item", "iwis", "ixia", "izar", "jabs", "jack", "jade", "jagg", "jags", "jail", "jake", "jamb", "jams", "jane", "jape", "jarl", "jars", "jato", "jauk", "jaup", "java", "jaws", "jays", "jazz", "jean", "jeed", "jeep", "jeer", "jees", "jeez", "jefe", "jehu", "jell", "jeon", "jerk", "jess", "jest", "jete", "jets", "jeux", "jews", "jiao", "jibb", "jibe", "jibs", "jiff", "jigs", "jill", "jilt", "jimp", "jink", "jinn", "jins", "jinx", "jism", "jive", "jivy", "jobs", "jock", "joes", "joey", "jogs", "john", "join", "joke", "joky", "jole", "jolt", "josh", "joss", "jota", "jots", "jouk", "jowl", "jows", "joys", "juba", "jube", "juco", "judo", "juga", "jugs", "juju", "juke", "juku", "jump", "junk", "jupe", "jura", "jury", "just", "jute", "juts", "kaas", "kabs", "kadi", "kaes", "kafs", "kagu", "kaif", "kail", "kain", "kaka", "kaki", "kale", "kame", "kami", "kana", "kane", "kaon", "kapa", "kaph", "karn", "kart", "kata", "kats", "kava", "kayo", "kays", "kbar", "keas", "keck", "keef", "keek", "keel", "keen", "keep", "keet", "kefs", "kegs", "keir", "kelp", "kelt", "kemp", "keno", "kens", "kent", "kepi", "keps", "kept", "kerb", "kerf", "kern", "keto", "keys", "khaf", "khan", "khat", "khet", "khis", "kibe", "kick", "kids", "kief", "kier", "kifs", "kike", "kill", "kiln", "kilo", "kilt", "kina", "kind", "kine", "king", "kink", "kino", "kins", "kips", "kirk", "kirn", "kirs", "kiss", "kist", "kite", "kith", "kits", "kiva", "kiwi", "klik", "knap", "knar", "knee", "knew", "knit", "knob", "knop", "knot", "know", "knur", "koan", "koas", "kobo", "kobs", "koel", "kohl", "kois", "koji", "kola", "kolo", "konk", "kook", "koph", "kops", "kora", "kore", "kors", "koss", "koto", "kris", "kudo", "kudu", "kues", "kufi", "kuna", "kune", "kuru", "kvas", "kyak", "kyar", "kyat", "kyes", "kyte", "labs", "lace", "lack", "lacs", "lacy", "lade", "lads", "lady", "lags", "laic", "laid", "lain", "lair", "lake", "lakh", "laky", "lall", "lama", "lamb", "lame", "lamp", "lams", "land", "lane", "lang", "lank", "laps", "lard", "lari", "lark", "lars", "lase", "lash", "lass", "last", "late", "lath", "lati", "lats", "latu", "laud", "lava", "lave", "lavs", "lawn", "laws", "lays", "laze", "lazy", "lead", "leaf", "leak", "leal", "lean", "leap", "lear", "leas", "lech", "leek", "leer", "lees", "leet", "left", "legs", "lehr", "leis", "leke", "leks", "leku", "lend", "leno", "lens", "lent", "lept", "less", "lest", "lets", "leud", "leva", "levo", "levy", "lewd", "leys", "liar", "libs", "lice", "lich", "lick", "lido", "lids", "lied", "lief", "lien", "lier", "lies", "lieu", "life", "lift", "like", "lilo", "lilt", "lily", "lima", "limb", "lime", "limn", "limo", "limp", "limy", "line", "ling", "link", "linn", "lino", "lins", "lint", "liny", "lion", "lipa", "lipe", "lips", "lira", "lire", "liri", "lisp", "list", "lite", "lits", "litu", "live", "load", "loaf", "loam", "loan", "lobe", "lobo", "lobs", "loca", "loch", "loci", "lock", "loco", "lode", "loft", "loge", "logo", "logs", "logy", "loid", "loin", "loll", "lone", "long", "loof", "look", "loom", "loon", "loop", "loos", "loot", "lope", "lops", "lord", "lore", "lorn", "lory", "lose", "loss", "lost", "lota", "loth", "loti", "lots", "loud", "loup", "lour", "lout", "love", "lowe", "lown", "lows", "luau", "lube", "luce", "luck", "lude", "lues", "luff", "luge", "lugs", "lull", "lulu", "luma", "lump", "lums", "luna", "lune", "lung", "lunk", "lunt", "luny", "lure", "lurk", "lush", "lust", "lute", "lutz", "luvs", "luxe", "lwei", "lych", "lyes", "lynx", "lyre", "lyse", "maar", "mabe", "mace", "mach", "mack", "macs", "made", "mads", "maes", "mage", "magi", "mags", "maid", "mail", "maim", "main", "mair", "make", "mako", "male", "mall", "malm", "malt", "mama", "mana", "mane", "mano", "mans", "many", "maps", "mara", "marc", "mare", "mark", "marl", "mars", "mart", "masa", "mash", "mask", "mass", "mast", "mate", "math", "mats", "matt", "maud", "maul", "maun", "maut", "mawn", "maws", "maxi", "maya", "mayo", "mays", "maze", "mazy", "mead", "meal", "mean", "meat", "meds", "meed", "meek", "meet", "mega", "megs", "meld", "mell", "mels", "melt", "meme", "memo", "mems", "mend", "meno", "menu", "meou", "meow", "merc", "mere", "merk", "merl", "mesa", "mesh", "mess", "meta", "mete", "meth", "mewl", "mews", "meze", "mhos", "mibs", "mica", "mice", "mick", "mics", "midi", "mids", "mien", "miff", "migg", "migs", "mike", "mild", "mile", "milk", "mill", "milo", "mils", "milt", "mime", "mina", "mind", "mine", "mini", "mink", "mint", "minx", "mips", "mire", "miri", "mirk", "mirs", "miry", "mise", "miso", "miss", "mist", "mite", "mitt", "mity", "mixt", "moan", "moas", "moat", "mobs", "mock", "mocs", "mode", "modi", "mods", "mogs", "moil", "mojo", "moke", "mola", "mold", "mole", "moll", "mols", "molt", "moly", "mome", "momi", "moms", "monk", "mono", "mons", "mony", "mood", "mool", "moon", "moor", "moos", "moot", "mope", "mops", "mopy", "mora", "more", "morn", "mors", "mort", "mosh", "mosk", "moss", "most", "mote", "moth", "mots", "mott", "moue", "move", "mown", "mows", "moxa", "mozo", "much", "muck", "muds", "muff", "mugg", "mugs", "mule", "mull", "mumm", "mump", "mums", "mumu", "muni", "muns", "muon", "mura", "mure", "murk", "murr", "muse", "mush", "musk", "muss", "must", "mute", "muts", "mutt", "mycs", "myna", "myth", "naan", "nabe", "nabs", "nada", "naff", "nags", "naif", "nail", "nala", "name", "nana", "nans", "naoi", "naos", "napa", "nape", "naps", "narc", "nard", "nark", "nary", "nave", "navy", "nays", "nazi", "neap", "near", "neat", "nebs", "neck", "need", "neem", "neep", "negs", "neif", "nema", "nene", "neon", "nerd", "ness", "nest", "nets", "nett", "neuk", "neum", "neve", "nevi", "news", "newt", "next", "nibs", "nice", "nick", "nide", "nidi", "nigh", "nill", "nils", "nims", "nine", "nipa", "nips", "nisi", "nite", "nits", "nixe", "nixy", "nobs", "nock", "node", "nodi", "nods", "noel", "noes", "nogg", "nogs", "noil", "noir", "nolo", "noma", "nome", "noms", "nona", "none", "nook", "noon", "nope", "nori", "norm", "nose", "nosh", "nosy", "nota", "note", "noun", "nous", "nova", "nows", "nowt", "nubs", "nude", "nuke", "null", "numb", "nuns", "nurd", "nurl", "nuts", "oafs", "oaks", "oaky", "oars", "oast", "oath", "oats", "obas", "obes", "obey", "obia", "obis", "obit", "oboe", "obol", "ocas", "odah", "odas", "odds", "odea", "odes", "odic", "odor", "odyl", "ofay", "offs", "ogam", "ogee", "ogle", "ogre", "ohed", "ohia", "ohms", "oils", "oily", "oink", "okas", "okay", "okeh", "okes", "okra", "olds", "oldy", "olea", "oleo", "oles", "olio", "olla", "omen", "omer", "omit", "once", "ones", "only", "onos", "onto", "onus", "onyx", "oohs", "oops", "oots", "ooze", "oozy", "opah", "opal", "oped", "open", "opes", "opts", "opus", "orad", "oral", "orbs", "orby", "orca", "orcs", "ordo", "ores", "orgy", "orle", "orra", "orts", "oryx", "orzo", "osar", "oses", "ossa", "otic", "otto", "ouch", "ouds", "ouph", "ours", "oust", "outs", "ouzo", "oval", "oven", "over", "ovum", "owed", "owes", "owls", "owns", "owse", "oxen", "oxes", "oxid", "oxim", "oyer", "oyes", "oyez", "paca", "pace", "pack", "pacs", "pact", "pacy", "padi", "pads", "page", "paid", "paik", "pail", "pain", "pair", "pale", "pall", "palm", "palp", "pals", "paly", "pams", "pane", "pang", "pans", "pant", "papa", "paps", "para", "pard", "pare", "park", "parr", "pars", "part", "pase", "pash", "pass", "past", "pate", "path", "pats", "paty", "pave", "pawl", "pawn", "paws", "pays", "peag", "peak", "peal", "pean", "pear", "peas", "peat", "pech", "peck", "pecs", "peds", "peed", "peek", "peel", "peen", "peep", "peer", "pees", "pegs", "pehs", "pein", "peke", "pele", "pelf", "pelt", "pend", "pens", "pent", "peon", "pepo", "peps", "pere", "peri", "perk", "perm", "perp", "pert", "perv", "peso", "pest", "pets", "pews", "pfft", "pfui", "phat", "phew", "phis", "phiz", "phon", "phot", "phut", "pial", "pian", "pias", "pica", "pice", "pick", "pics", "pied", "pier", "pies", "pigs", "pika", "pike", "piki", "pile", "pili", "pill", "pily", "pima", "pimp", "pina", "pine", "ping", "pink", "pins", "pint", "piny", "pion", "pipe", "pips", "pipy", "pirn", "pish", "piso", "piss", "pita", "pith", "pits", "pity", "pixy", "plan", "plat", "play", "plea", "pleb", "pled", "plew", "plex", "plie", "plod", "plop", "plot", "plow", "ploy", "plug", "plum", "plus", "pock", "poco", "pods", "poem", "poet", "pogy", "pois", "poke", "poky", "pole", "poll", "polo", "pols", "poly", "pome", "pomo", "pomp", "poms", "pond", "pone", "pong", "pons", "pony", "pood", "poof", "pooh", "pool", "poon", "poop", "poor", "poos", "pope", "pops", "pore", "pork", "porn", "port", "pose", "posh", "post", "posy", "pots", "pouf", "pour", "pout", "pows", "poxy", "pram", "prao", "prat", "prau", "pray", "pree", "prep", "prex", "prey", "prez", "prig", "prim", "proa", "prod", "prof", "prog", "prom", "prop", "pros", "prow", "psis", "psst", "ptui", "pubs", "puce", "puck", "puds", "puff", "pugh", "pugs", "puja", "puke", "pula", "pule", "puli", "pull", "pulp", "puls", "puma", "pump", "puna", "pung", "punk", "puns", "punt", "puny", "pupa", "pups", "pupu", "pure", "puri", "purl", "purr", "purs", "push", "puss", "puts", "putt", "putz", "pyas", "pyes", "pyic", "pyin", "pyre", "pyro", "qadi", "qaid", "qats", "qoph", "quad", "quag", "quai", "quay", "quey", "quid", "quin", "quip", "quit", "quiz", "quod", "race", "rack", "racy", "rads", "raff", "raft", "raga", "rage", "ragg", "ragi", "rags", "raia", "raid", "rail", "rain", "rais", "raja", "rake", "raki", "raku", "rale", "rami", "ramp", "rams", "rand", "rang", "rani", "rank", "rant", "rape", "raps", "rapt", "rare", "rase", "rash", "rasp", "rate", "rath", "rato", "rats", "rave", "raws", "raya", "rays", "raze", "razz", "read", "real", "ream", "reap", "rear", "rebs", "reck", "recs", "redd", "rede", "redo", "reds", "reed", "reef", "reek", "reel", "rees", "refs", "reft", "regs", "reif", "rein", "reis", "rely", "rems", "rend", "rent", "repo", "repp", "reps", "resh", "rest", "rete", "rets", "revs", "rhea", "rhos", "rhus", "rial", "rias", "ribs", "rice", "rich", "rick", "ride", "rids", "riel", "rife", "riff", "rifs", "rift", "rigs", "rile", "rill", "rime", "rims", "rimy", "rind", "ring", "rink", "rins", "riot", "ripe", "rips", "rise", "risk", "rite", "ritz", "rive", "road", "roam", "roan", "roar", "robe", "robs", "rock", "rocs", "rode", "rods", "roes", "roil", "role", "rolf", "roll", "romp", "roms", "rood", "roof", "rook", "room", "root", "rope", "ropy", "rose", "rosy", "rota", "rote", "roti", "rotl", "roto", "rots", "roue", "roup", "rout", "roux", "rove", "rows", "rube", "rubs", "ruby", "ruck", "rudd", "rude", "rued", "ruer", "rues", "ruff", "ruga", "rugs", "ruin", "rule", "ruly", "rump", "rums", "rune", "rung", "runs", "runt", "ruse", "rush", "rusk", "rust", "ruth", "ruts", "ryas", "ryes", "ryke", "rynd", "ryot", "sabe", "sabs", "sack", "sacs", "sade", "sadi", "safe", "saga", "sage", "sago", "sags", "sagy", "said", "sail", "sain", "sake", "saki", "sale", "sall", "salp", "sals", "salt", "same", "samp", "sand", "sane", "sang", "sank", "sans", "saps", "sard", "sari", "sark", "sash", "sass", "sate", "sati", "saul", "save", "sawn", "saws", "says", "scab", "scad", "scag", "scam", "scan", "scar", "scat", "scop", "scot", "scow", "scry", "scud", "scum", "scup", "scut", "seal", "seam", "sear", "seas", "seat", "secs", "sect", "seed", "seek", "seel", "seem", "seen", "seep", "seer", "sees", "sego", "segs", "seif", "seis", "self", "sell", "sels", "seme", "semi", "send", "sene", "sent", "sept", "sera", "sere", "serf", "sers", "seta", "sets", "sett", "sewn", "sews", "sext", "sexy", "shad", "shag", "shah", "sham", "shat", "shaw", "shay", "shea", "shed", "shes", "shew", "shim", "shin", "ship", "shit", "shiv", "shmo", "shod", "shoe", "shog", "shoo", "shop", "shot", "show", "shri", "shul", "shun", "shut", "shwa", "sial", "sibb", "sibs", "sice", "sick", "sics", "side", "sidh", "sift", "sigh", "sign", "sika", "sike", "sild", "silk", "sill", "silo", "silt", "sima", "simp", "sims", "sine", "sing", "sinh", "sink", "sins", "sipe", "sips", "sire", "sirs", "site", "sith", "sits", "size", "sizy", "skag", "skas", "skat", "skee", "skeg", "skep", "skew", "skid", "skim", "skin", "skip", "skis", "skit", "skua", "slab", "slag", "slam", "slap", "slat", "slaw", "slay", "sled", "slew", "slid", "slim", "slip", "slit", "slob", "sloe", "slog", "slop", "slot", "slow", "slub", "slue", "slug", "slum", "slur", "slut", "smew", "smit", "smog", "smug", "smut", "snag", "snap", "snaw", "sned", "snib", "snip", "snit", "snob", "snog", "snot", "snow", "snub", "snug", "snye", "soak", "soap", "soar", "soba", "sobs", "soca", "sock", "soda", "sods", "sofa", "soft", "soil", "soja", "soke", "sola", "sold", "sole", "soli", "solo", "sols", "soma", "some", "soms", "sone", "song", "sons", "sook", "soon", "soot", "soph", "sops", "sora", "sorb", "sord", "sore", "sori", "sorn", "sort", "soth", "sots", "souk", "soul", "soup", "sour", "sous", "sown", "sows", "soya", "soys", "spae", "spam", "span", "spar", "spas", "spat", "spay", "spaz", "spec", "sped", "spew", "spic", "spik", "spin", "spit", "spiv", "spot", "spry", "spud", "spue", "spun", "spur", "sris", "stab", "stag", "star", "stat", "staw", "stay", "stem", "step", "stet", "stew", "stey", "stir", "stoa", "stob", "stop", "stot", "stow", "stub", "stud", "stum", "stun", "stye", "suba", "subs", "such", "suck", "sudd", "suds", "sued", "suer", "sues", "suet", "sugh", "suit", "suks", "sulk", "sulu", "sumo", "sump", "sums", "sung", "sunk", "sunn", "suns", "supe", "sups", "suqs", "sura", "surd", "sure", "surf", "suss", "swab", "swag", "swam", "swan", "swap", "swat", "sway", "swig", "swim", "swob", "swop", "swot", "swum", "sybo", "syce", "syke", "syli", "sync", "syne", "syph", "tabs", "tabu", "tace", "tach", "tack", "taco", "tact", "tads", "tael", "tags", "tahr", "tail", "tain", "taka", "take", "tala", "talc", "tale", "tali", "talk", "tall", "tame", "tamp", "tams", "tang", "tank", "tans", "taos", "tapa", "tape", "taps", "tare", "tarn", "taro", "tarp", "tars", "tart", "task", "tass", "tate", "tats", "taus", "taut", "tavs", "taws", "taxa", "taxi", "teak", "teal", "team", "tear", "teas", "teat", "tech", "teds", "teed", "teel", "teem", "teen", "tees", "teff", "tegg", "tegs", "tela", "tele", "tell", "tels", "temp", "tend", "tens", "tent", "tepa", "term", "tern", "test", "teth", "tets", "tews", "text", "thae", "than", "that", "thaw", "thee", "them", "then", "thew", "they", "thin", "thio", "thir", "this", "thou", "thro", "thru", "thud", "thug", "thus", "tick", "tics", "tide", "tidy", "tied", "tier", "ties", "tiff", "tike", "tiki", "tile", "till", "tils", "tilt", "time", "tine", "ting", "tins", "tint", "tiny", "tipi", "tips", "tire", "tirl", "tiro", "titi", "tits", "tivy", "toad", "toby", "tods", "tody", "toea", "toed", "toes", "toff", "toft", "tofu", "toga", "togs", "toil", "toit", "toke", "tola", "told", "tole", "toll", "tolu", "tomb", "tome", "toms", "tone", "tong", "tons", "tony", "took", "tool", "toom", "toon", "toot", "tope", "toph", "topi", "topo", "tops", "tora", "torc", "tore", "tori", "torn", "toro", "torr", "tors", "tort", "tory", "tosh", "toss", "tost", "tote", "tots", "tour", "tout", "town", "tows", "towy", "toyo", "toys", "trad", "tram", "trap", "tray", "tree", "tref", "trek", "tres", "tret", "trey", "trig", "trim", "trio", "trip", "trod", "trog", "trop", "trot", "trow", "troy", "true", "trug", "tsar", "tsks", "tuba", "tube", "tubs", "tuck", "tufa", "tuff", "tuft", "tugs", "tuis", "tule", "tump", "tuna", "tune", "tung", "tuns", "tups", "turd", "turf", "turk", "turn", "tush", "tusk", "tuts", "tutu", "twae", "twas", "twat", "twee", "twig", "twin", "twit", "twos", "tyee", "tyer", "tyes", "tyin", "tyke", "tyne", "type", "typo", "typp", "typy", "tyre", "tyro", "tzar", "udon", "udos", "ughs", "ugly", "ukes", "ulan", "ulna", "ulus", "ulva", "umbo", "umps", "unai", "unau", "unbe", "unci", "unco", "unde", "undo", "undy", "unit", "unto", "upas", "upby", "updo", "upon", "urbs", "urds", "urea", "urge", "uric", "urns", "urps", "ursa", "urus", "used", "user", "uses", "utas", "utes", "uvea", "vacs", "vagi", "vail", "vain", "vair", "vale", "vamp", "vane", "vang", "vans", "vara", "vars", "vary", "vasa", "vase", "vast", "vats", "vatu", "vaus", "vavs", "vaws", "veal", "veep", "veer", "vees", "veil", "vein", "vela", "veld", "vena", "vend", "vent", "vera", "verb", "vert", "very", "vest", "veto", "vets", "vext", "vial", "vibe", "vice", "vide", "vids", "vied", "vier", "vies", "view", "viga", "vigs", "vile", "vill", "vims", "vina", "vine", "vino", "viny", "viol", "virl", "visa", "vise", "vita", "viva", "vive", "voes", "void", "vole", "volt", "vote", "vows", "vrow", "vugg", "vugh", "vugs", "wabs", "wack", "wade", "wadi", "wads", "wady", "waes", "waff", "waft", "wage", "wags", "waif", "wail", "wain", "wair", "wait", "wake", "wale", "walk", "wall", "waly", "wame", "wand", "wane", "wank", "wans", "want", "wany", "waps", "ward", "ware", "wark", "warm", "warn", "warp", "wars", "wart", "wary", "wash", "wasp", "wast", "wats", "watt", "wauk", "waul", "waur", "wave", "wavy", "wawl", "waws", "waxy", "ways", "weak", "weal", "wean", "wear", "webs", "weds", "weed", "week", "weel", "ween", "weep", "weer", "wees", "weet", "weft", "weir", "weka", "weld", "well", "welt", "wend", "wens", "went", "wept", "were", "wert", "west", "wets", "wham", "whap", "what", "whee", "when", "whet", "whew", "whey", "whid", "whig", "whim", "whin", "whip", "whir", "whit", "whiz", "whoa", "whom", "whop", "whup", "whys", "wich", "wick", "wide", "wife", "wigs", "wild", "wile", "will", "wilt", "wily", "wimp", "wind", "wine", "wing", "wink", "wino", "wins", "winy", "wipe", "wire", "wiry", "wise", "wish", "wisp", "wiss", "wist", "wite", "with", "wits", "wive", "woad", "woes", "wogs", "woke", "woks", "wold", "wolf", "womb", "wonk", "wons", "wont", "wood", "woof", "wool", "woos", "wops", "word", "wore", "work", "worm", "worn", "wort", "wost", "wots", "wove", "wows", "wrap", "wren", "writ", "wuss", "wych", "wyes", "wyle", "wynd", "wynn", "wyns", "wyte", "xyst", "yack", "yaff", "yagi", "yags", "yaks", "yald", "yams", "yang", "yank", "yaps", "yard", "yare", "yarn", "yaud", "yaup", "yawl", "yawn", "yawp", "yaws", "yays", "yeah", "yean", "year", "yeas", "yech", "yegg", "yeld", "yelk", "yell", "yelp", "yens", "yeps", "yerk", "yeti", "yett", "yeuk", "yews", "yids", "yill", "yins", "yipe", "yips", "yird", "yirr", "ylem", "yobs", "yock", "yodh", "yods", "yoga", "yogh", "yogi", "yoke", "yoks", "yolk", "yond", "yoni", "yore", "your", "yous", "yowe", "yowl", "yows", "yuan", "yuca", "yuch", "yuck", "yuga", "yuks", "yule", "yups", "yurt", "yutz", "ywis", "zags", "zany", "zaps", "zarf", "zeal", "zebu", "zeds", "zees", "zein", "zeks", "zeps", "zerk", "zero", "zest", "zeta", "zigs", "zill", "zinc", "zine", "zing", "zins", "zips", "ziti", "zits", "zoea", "zoic", "zona", "zone", "zonk", "zoom", "zoon", "zoos", "zori", "zouk", "zyme" };
            Random rnd = new Random() ;
        
            int value = rnd.Next(1000);
            string text = value.ToString("000");

            string password = passwordStrings[rnd.Next(0,passwordStrings.Length-1)].ToString() + text;

            user user = db.users
               .Where(x => x.mobile == mobileNo)
               .FirstOrDefault();

            if (user == null)
            {
                return 0;
            }
            else
            {
                user.password = Encrypt(password);
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() == 1)
                {
                    string sendSingleSmsUrl = WebConfigurationManager.AppSettings["sendSingleSmsUrl"];
                    string smsUserId = WebConfigurationManager.AppSettings["smsUserId"];
                    string smsPassword = WebConfigurationManager.AppSettings["smsPassword"];
                    string smsFrom = WebConfigurationManager.AppSettings["smsFrom"];
                    string smsResetPasswordTemplate = WebConfigurationManager.AppSettings["smsResetPasswordTemplate"];
                    string defaultPassword = WebConfigurationManager.AppSettings["defaultPassword"];

                    TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

                    smsResetPasswordTemplate = String.Format(smsResetPasswordTemplate, password);
                    sendSingleSmsUrl = String.Format(sendSingleSmsUrl, smsUserId, smsPassword, smsFrom, user.mobile, smsResetPasswordTemplate, "&");

                    string output;

                    using (WebClient client = new WebClient())
                    {
                        output = client.DownloadString(sendSingleSmsUrl);
                    }

                    smsoutput smsoutput = new smsoutput();

                    smsoutput.sentAction = "p";
                    smsoutput.output = output;
                    smsoutput.createDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    smsoutput.actionid = user.id;

                    db.smsoutputs.Add(smsoutput);
                    db.SaveChanges();
                }
                return 1;
            }
        }

        
        [HttpPost]
        [Route("updateLBD/")]
        
        public dynamic updateLBD(lbdModelClass lbdData)
        {

            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                user user = db.users.Find(lbdData.userId);
                user.lbd = lbdData.lbd;
                db.Entry(user).State = EntityState.Modified;

                int saveChanges = db.SaveChanges();

                return lbdData.lbd;
            }
            catch (Exception ex)
            {
                return "unknown";
            }
        }


        [Route("validate/{mobile}/{password}")]
        [HttpGet]
        public List<user> checkLogin(long mobile, string password)
        {

            db.Configuration.ProxyCreationEnabled = false;

            password = Encrypt(password);

            List<user> userList = (from recordset in db.users
                       where recordset.mobile == mobile && recordset.password.Equals(password)
                       select recordset).ToList();

            //if (userList.Count() == 1)
            //{
            //}

            return userList;
        }

        // POST: api/users
        [ResponseType(typeof(user))]
        public IHttpActionResult Postuser(user user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string defaultPassword = WebConfigurationManager.AppSettings["defaultPassword"];

            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

            user.createdate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            user.password = Encrypt(defaultPassword);
            user.status = "1";

            db.users.Add(user);
            db.SaveChanges();

            if (user.id > 0) {

                string sendSingleSmsUrl = WebConfigurationManager.AppSettings["sendSingleSmsUrl"];
                string smsUserId = WebConfigurationManager.AppSettings["smsUserId"];
                string smsPassword = WebConfigurationManager.AppSettings["smsPassword"];
                string smsFrom = WebConfigurationManager.AppSettings["smsFrom"];
                string smsRegisterMsgTemplate = WebConfigurationManager.AppSettings["smsRegisterMsgTemplate"];

                smsRegisterMsgTemplate = String.Format(smsRegisterMsgTemplate, user.fullname.Replace(" ", "+"), user.mobile, defaultPassword);
                sendSingleSmsUrl = String.Format(sendSingleSmsUrl, smsUserId, smsPassword, smsFrom, user.mobile, smsRegisterMsgTemplate, "&");

                string output;

                using (WebClient client = new WebClient())
                {
                    output = client.DownloadString(sendSingleSmsUrl);
                }

                smsoutput smsoutput = new smsoutput();

                smsoutput.sentAction = "r";
                smsoutput.output = output;
                smsoutput.createDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                smsoutput.actionid = user.id;

                db.smsoutputs.Add(smsoutput);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = user.id }, user);
        }

        [Route("sendBloodDonorSMS/{mobile}")]
        [HttpGet]

        public dynamic sendBloodDonorSMS(Int64 mobile)
        {
            string smsBloodDonorsDay = WebConfigurationManager.AppSettings["smsBloodDonorsDay"];
            string sendSingleSmsUrl = WebConfigurationManager.AppSettings["sendSingleSmsUrl"];
            string smsUserId = WebConfigurationManager.AppSettings["smsUserId"];
            string smsPassword = WebConfigurationManager.AppSettings["smsPassword"];
            string smsFrom = WebConfigurationManager.AppSettings["smsFrom"];
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

            sendSingleSmsUrl = String.Format(sendSingleSmsUrl, smsUserId, smsPassword, smsFrom, mobile, smsBloodDonorsDay, "&");


            using (WebClient client = new WebClient())
            {
                if (mobile != 9115625847) { 
                smsoutput smsoutput = new smsoutput();

                smsoutput.sentAction = "m";
                smsoutput.output = client.DownloadString(sendSingleSmsUrl); ;
                smsoutput.createDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                smsoutput.actionid = mobile;

                db.smsoutputs.Add(smsoutput);
                return db.SaveChanges();
                }

                return "Change the mobile number to which you need to send";
                 
            }

        }

        // DELETE: api/users/5
        [ResponseType(typeof(user))]
        public IHttpActionResult Deleteuser(int id)
        {
            user user = db.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool userExists(int id)
        {
            return db.users.Count(e => e.id == id) > 0;
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}