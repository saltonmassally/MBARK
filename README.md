# &nbsp;

# **MBARK**

<font color="#6699cc" size="+1">**Multimodal Biometric Application Resource Kit**</font>

### _Navigate this page_

<table summary="Table Summary" align="center" border="1" cellpadding="2" cellspacing="2" width="100%">
<tbody>
<tr>
<td align="center">

**[<font color="#993333">_About_</font>](/itl/iad/ig/mbark.cfm#about)**

</td>
<td>

[**<font color="#993333">_Recent Developments_</font>**](/itl/iad/ig/mbark.cfm#dev)

</td>
<td>

[**<font color="#993333">_Downloads_</font>**](/itl/iad/ig/mbark.cfm#downloads)

</td>
<td>

[**<font color="#993333">_Screenshots_</font>**](/itl/iad/ig/mbark.cfm#screenshots)

</td>
</tr>
<tr>
<td>

[**<font color="#993333">_Sensors_</font>**](/itl/iad/ig/mbark.cfm#sensors)

</td>
<td>

[**<font color="#993333">_Features_</font>**](/itl/iad/ig/mbark.cfm#features)

</td>
<td>

[**<font color="#993333">_Documents_</font>**](/itl/iad/ig/mbark.cfm#documents)

</td>
<td>

[**<font color="#993333">_License_</font>**](/itl/iad/ig/mbark.cfm#license)

</td>
</tr>
<tr>
<td>

[**<font color="#993333">_Disclaimer_</font>**](/itl/iad/ig/mbark.cfm#disclaimer)

</td>
<td>

[**<font color="#993333">_Important Notes_</font>**](/itl/iad/ig/mbark.cfm#notes)

</td>
<td>

[**<font color="#993333">_Contact_</font>**](/itl/iad/ig/mbark.cfm#contact)

</td>
<td>

&nbsp;

</td>
</tr>
</tbody>
</table>

&nbsp;

## <a id="about" name="about"><font color="#993333">_About_</font></a>

Despite existing efforts, <!-- such as BioAPI, -->building modern biometric applications (or clients) that are flexible with respect to changes in sensors, workflow, configuration, and responsiveness remains both difficult and costly. The Multimodal Biometric Application Resource Kit, or MBARK reduces the complexity and costs of implementing such an application. MBARK is public domain source code that may be leveraged to develop the next-generation of biometric and personal identity verification applications.

Incorporating the MBARK libraries can yield a variety of enhancements critical for the success of any real-world system. For example, MBARK provides a usability-tested and consistent user interface. MBARK provides operators means to quickly recover from both minor mistakes and major hardware failures. In addition, the use of Extensible Markup Language (XML) facilitates true sensor interoperability via plug-ins and allows for changes in workflow on-the-fly.

**MBARK represents an immediate and field-tested response to** [**The National Biometric Challenge (PDF, ~471 KB)**](http://www.biometrics.gov/NSTC/pubs/biochallengedoc.pdf) **of developing middleware techniques and standards that will permit** **plug-and-play** **capabilities for biometric sensors.**

## &nbsp;

## _<a id="dev" name="dev"><font color="#993333">Recent Developments</font></a>_

*   MBARK is available via this website in two different versions. A prebuilt binary installer, for those who want to try MBARK right away, and the source code, for those who would rather build it from scratch.
*   MBARK now supports the Biometrics Client Configuration Language, or BiCCL, as described in [NIST IR 7531 (PDF, ~307 KB)](http://www.nist.gov/customcf/get_pdf.cfm?pub_id=33208). BiCCL is a simple, domain-specific language that can be used for formally describing biometric client configurations and desired workflows. BiCCL was not designed to be exclusive to MBARK — it is a domain specific, not an application specific, language.

## &nbsp;

## _<a id="downloads" name="downloads"><font color="#993333">Download</font></a>_

An updated version of the MBARK source code is now available. This version, based on .NET 3.5 SP1, features virtual sensors&nbsp;so that developers and evaluators may experiment with the functionality of MBARK without needing any particular additional hardware (e.g., digital camera, fingerprint sensors).

*   Download: [MBARK Virtual Sensor Demo Installer - June 2009 (MSI, ~4.8 MB)](http://biometrics.nist.gov/cs_links/mbark/release/MBARK-Jun09-Demo.msi)
*   Download: [MBARK Public Domain Source Code - June 2009 (ZIP, ~2.2 MB)](http://biometrics.nist.gov/cs_links/mbark/release/MBARK-Jun09-Source.zip)
*   Download: [MBARK Public Domain Source Code Build Instructions - June 2009 (PDF, ~439 KB)](http://biometrics.nist.gov/cs_links/mbark/release/MBARK-Jun09-BuildInstructions.pdf)

&nbsp;

Before running the installer, you may want to [download the latest version of the .NET Framework](http://smallestdotnet.com/). (This is a direct link away from this page.)

This release of MBARK is sponsored by:

*   Standards Portfolio, Science &amp; Technology Directorate, Department of Homeland Security
*   Criminal Justice Information Services, Federal Bureau of Investigation, Department fof Justice

&nbsp;

## <a id="screenshots" name="screenshots"><font color="#993333">_Screenshots_</font></a>

Some screenshots of an internal MBARK build in action with real sensors. Click on the thumbnails for a detailed image.

<table summary="Table Summary" border="1" cellpadding="2" cellspacing="2" width="100%">
<tbody>
<tr>
<td align="center" valign="middle">

&nbsp;**Successful capture.** This screenshot shows a successful <span class="titleTip" title="Four fingers (no thumb) from the left hand placed flat on the sensor platten.">left slap</span>. The large indicator of success fades away over a few second interval.

</td>
<td>

![success](/itl/iad/ig/images/success_1.png "success")&nbsp;

[(1152 x 835 PNG, ~290 KB)](/itl/iad/ig/images/success_1.png)

</td>
</tr>
<tr>
<td align="center" valign="middle">

**Polling for fingerprints with a live preview.** This screenshot is shows a <span class="titleTip" title="Four fingers (no thumb) from the right hand placed flat on the sensor platten.">right slap</span> in progress. The result from the previous task, a left slap, is visible in the upper-right hand panel of the window.

</td>
<td>

&nbsp;![capturing](/itl/iad/ig/images/capturing.png "capturing")

[(1152 x 835 PNG, ~290 KB)](/itl/iad/ig/images/capturing.png)

</td>
</tr>
<tr>
<td align="center" valign="middle">

**Handling a sensor failure.** This screenshot shows how MBARK prompts the operator when a sensor fails; in this case upon initialization. MBARK will either disable the sensor, or try to reset it automatically.

</td>
<td>

&nbsp;![failed_init](/itl/iad/ig/images/failed_init.png "failed_init")

[(1152 x 835 PNG, ~165 KB)](/itl/iad/ig/images/failed_init.png)

</td>
</tr>
</tbody>
</table>

&nbsp;

## <a id="sensors" name="sensors"><font color="#993333">_Sensors_</font></a>

The NIST Biometric Clients Lab has developed plug-ins&nbsp;for a variety of sensors in use by project stakeholders. The following table describes a variety of biometric sensors and their current implementation status within MBARK. **Source code to sensor plugins is available upon request.**

<center><span>[<span>Table of biometric sensors and their current implementation status within&nbsp;MBARK</span>](http://biometrics.nist.gov/cs_links/mbark/docs/Manufacturer.pdf)</span></center>

MBARK also includes a general BioAPI sensor interop layer based upon H. Kaiser Yang`s [C# wrapped Biometric API project](http://sourceforge.net/projects/boiapi-dt). The Biometric Clients Lab is always interested in expanding MBARK's capabilities by integrating new sensors. If there is a sensor that you would like to see integrated into MBARK, please e-mail us at [mbark@nist.gov](mailto:mbark@nist.gov).

&nbsp;

## <a id="features" name="features"><font color="#993333">_Features_</font></a>

The following are just some of the features of MBARK that make it robust and flexible with respect to changes in sensors, workflow, configuration, and responsiveness.

**Provides a consistent user interface**

> Often biometric systems change interfaces depending on which sensors are being used. MBARK, however, provides a consistent and user-centered interface, reducing errors and minimizing the need to retrain users as vendors develop new sensors and software. User-centered design is a formal process that helps ensure the efficiency, effectiveness, and user-satisfaction of a system throughout the system's lifecycle.

**Allows users to recover from mistakes**

> Significant costs may accompany any system that does not allow recovery from both common and uncommon mistakes. With MBARK, an operator not only easily recover from mistakes, but may also save a snapshot of a session (in the form of an XML file), allowing that session to be re-loaded at a later time.

**Adjusts workflow automatically**

> Defining a workflow that accomodates mistakes becomes more complex as edge cases are added. For example, how should the system behave if a fingerprint sensor detects that a finger is missing, but the operator has not indicated such?

**Responds to user input**

> Users expect modern applications to be responsive to their input at all times during initialization, startup, capture, task editing, and so on. How does a user distinguish between a long-running operation and a system that is simply frozen? MBARK uses a natively multi-threaded architecture to allow as much background processing as possible.

**Provides true sensor interoperability**

> MBARK uses a plug-in style mechanism that allows true sensor interoperability based on a unified API a common interface that has been used to successfully integrate real face cameras, fingerprint scanners and iris sensors. The MBARK architecture allows new sensors to be deployed without the need to even restart an MBARK application.

**Provides flexible user configuration**

> A highly configurable biometric client empowers users to define and experiment with various biometrics and workflows, without depending on any particular vendor to implement such changes. With XML files, MBARK allows users to define precise custom workflows specifically tailored to their needs.

**Open and free**

> MBARK source code is public domain the benefits of free software are well-discussed elsewhere. The GNU document [Categories of Free and Non-Free Software](http://www.gnu.org/philosophy/categories.html) contains more information about the differences between open source and public domain software.

&nbsp;

## <a id="documents" name="documents"><font color="#993333">_Documents_</font></a>

**MBARK "Glossy" Brochure**

*   Much of the information on this webpage is now available in a separately downloadable brochure about the project. Download: [MBARK Brochure (PDF, ~2.72 MB)](http://biometrics.nist.gov/cs_links/mbark/docs/MBARK_brochure.pdf). Hard copies are available upon request.

&nbsp;

**A Biometric Configuration Domain-Specific Language (DSL)**

*   [NIST IR 7531: The Biometric Clients Configuration Language (BiCCL) (PDF, ~307 KB)](http://www.nist.gov/customcf/get_pdf.cfm?pub_id=33208)
> This paper introduces the Biometric Client Configuration Language, or BiCCL. BiCCL is a platform-independent, domain-specific language (DSL) that formally describes the biometric acquisition process. BiCCL uses high-level constructs — e.g., sensors, tasks, experimental conditions, and workflow — to help users directly encode their intent. To test the expressiveness of this new DSL, a reference compiler was built that translates BiCCL directly into XML that can be consumed by MBARK.&nbsp;

**Usablity Evaluation of the MBARK User Interface**

*   [Session Interface Usability Study (PDF, ~167 KB)](http://biometrics.nist.gov/cs_links/mbark/docs/UI_evaluation.pdf)
> Before any code was written, the [NIST Visualization and Usability Group](http://www.nist.gov/itl/iad/vug) performed a usabilty test on a prototype of the primary operator interface. Results were reported according to [ISO/IEC 25062:2006](http://www.iso.org/iso/en/CatalogueDetailPage.CatalogueDetail?CSNUMBER=43046&amp;ICS1=35&amp;ICS2=80&amp;ICS3=)&nbsp;known at NIST as the [CIF](http://zing.ncsl.nist.gov/iusr/). The output of this document was the direct driver for the current MBARK user interface.

&nbsp;

## <a id="license" name="license"><font color="#993333">_License_</font></a>

This software was developed at the National Institute of Standards and Technology (NIST) by employees of the Federal Government in the course of their official duties. Pursuant to [Title 17 Section 105 of the United States Code](http://www.copyright.gov/title17/92chap1.html#105), this software is not subject to copyright protection and is in the public domain. NIST assumes no responsibility whatsoever for use by other parties of its source code or open source server, and makes no guarantees, expressed or implied, about its quality, reliability, or any other characteristic.

&nbsp;

## <a id="disclaimer" name="disclaimer"><font color="#993333">_Disclaimer_</font></a>

Specific hardware and software products identified in this open source project were used in order to perform technology transfer and collaboration. In no case does such identification imply recommendation or endorsement by the National Institute of Standards and Technology, nor does it imply that the products and equipment identified are necessarily the best available for the purpose.

&nbsp;

## <a id="notes" name="notes"><font color="#993333">_Other Notes_</font></a>

*   Although it is being developed at the National Institute of Standards and Technology (NIST), MBARK is primarily sponsored by the Standards Portfolio of the Department of Homeland Security's Science and Technology Directorate.
*   The MBARK acronym originally stood for the Multimodal Biometric Accuracy Research Kiosk since it was envisioned as a tool to develop a large database of face, fingerprint and iris images for performance testing of biometric systems.
*   The [USA PATRIOT Act](http://thomas.loc.gov/cgi-bin/query/z?c107:H.R.3162.ENR:) and the [Enhanced Border Security and Visa Entry Reform Act](http://thomas.loc.gov/cgi-bin/query/z?c107:H.R.3525.ENR:) calls for NIST to develop and certify standards for verifying the identity of individuals and determining the accuracy of biometric technologies, including fingerprints, facial recognition and iris recognition.

&nbsp;

## <a id="contact" name="contact"><font color="#993333">_Contact_</font></a>

Comments and questions about MBARK should be addressed to [mbark@nist.gov](mailto:mbark@nist.gov). By nature of its development, MBARK is public domain source, and provided **as is**; it is not supported in the same fashion that a for-profit company might provide technical support for a software product.
