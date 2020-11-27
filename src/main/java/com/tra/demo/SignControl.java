package com.tra.demo;

/*
import fr.opensagres.poi.xwpf.converter.pdf.PdfConverter;
import fr.opensagres.poi.xwpf.converter.pdf.PdfOptions;
import org.apache.fop.apps.Fop;
import org.apache.fop.apps.FopFactory;
import org.apache.fop.apps.MimeConstants;
import org.apache.poi.hwpf.converter.WordToFoConverter;
import org.apache.poi.xwpf.usermodel.XWPFDocument;
import com.artofsolving.jodconverter.openoffice.connection.OpenOfficeConnection;
import com.artofsolving.jodconverter.openoffice.connection.SocketOpenOfficeConnection;
import com.artofsolving.jodconverter.openoffice.converter.OpenOfficeDocumentConverter;
import org.apache.fop.apps.Fop;
import org.apache.fop.apps.FopFactory;
import org.apache.poi.xwpf.converter.pdf.PdfConverter;
import org.apache.poi.xwpf.converter.pdf.PdfOptions;
import org.apache.poi.xwpf.usermodel.XWPFDocument;
import org.jodconverter.DocumentConverter;*/

import com.artofsolving.jodconverter.DocumentConverter;
import com.artofsolving.jodconverter.openoffice.connection.OpenOfficeConnection;
import com.artofsolving.jodconverter.openoffice.connection.SocketOpenOfficeConnection;
import com.artofsolving.jodconverter.openoffice.converter.OpenOfficeDocumentConverter;
import com.artofsolving.jodconverter.openoffice.converter.StreamOpenOfficeDocumentConverter;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.xml.sax.SAXException;

import javax.xml.transform.*;
import javax.xml.transform.sax.SAXResult;
import javax.xml.transform.stream.StreamSource;
import java.io.*;
import java.util.Map;
import java.util.UUID;


@RequestMapping("pdfShow")
@Controller
public class SignControl {


    @RequestMapping(value = "apiPdfUpload/{id}", method = RequestMethod.POST)
    @ResponseBody
    public void H5SginApiPdfUpload(@PathVariable String id) throws Exception {
        String filepath = "D:\\contract\\pic.doc";
        String filepathpdf = "D:\\contract\\contract2.pdf";
        try {
            WordToPDF(filepath, filepathpdf);
            //convertPdf(filepath, filepathpdf, null);
            // test1DocToPDF(filepath, filepathpdf);
        } catch (IOException e) {
            int ddd;
            //   br.close();
        }
    }

    // 将word格式的文件转换为pdf格式
    public static void WordToPDF(String startFile, String overFile) throws IOException {
// 源文件目录
        File inputFile = new File(startFile);
        if (!inputFile.exists()) {
            System.out.println("源文件不存在！");
            return;
        }

// 输出文件目录
        File outputFile = new File(overFile);
        if (!outputFile.getParentFile().exists()) {
            outputFile.getParentFile().exists();
        }

// 调用openoffice服务线程
/** 我把openOffice下载到了 C:/Program Files (x86)/下 ,下面的写法自己修改编辑就可以**/
        //String command = "C:/Program Files (x86)/OpenOffice 4/program/soffice.exe -headless -accept=\"socket,host=127.0.0.1,port=8100;urp;\"";
        // Process p = Runtime.getRuntime().exec(command);

// 连接openoffice服务
        OpenOfficeConnection connection = new SocketOpenOfficeConnection("127.0.0.1", 8100);
        try {
            connection.connect();

// 转换
            DocumentConverter converter = (DocumentConverter) new StreamOpenOfficeDocumentConverter(connection);
            converter.convert(inputFile, outputFile);

// 关闭连接
            connection.disconnect();
        } catch (java.net.ConnectException e) {
            e.printStackTrace();
            System.out.println("****openoffice服务未启动！****");
            // logger.error(e, e);
        } catch (com.artofsolving.jodconverter.openoffice.connection.OpenOfficeException e) {
            e.printStackTrace();
            System.out.println("****读取转换文件失败****");
            // logger.error(e, e);
        } catch (Exception e) {
            e.printStackTrace();
            //  logger.error(e, e);
        }
// 关闭进程
        // p.destroy();
    }

/*
    public static void main(String[] args) {
        String start = "F:\\新建文件夹\\我是word测试文件.docx";
        String over = "F:\\新建文件夹\\成了.pdf";
        try {
            WordToPDF(start, over);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }


    public void convertPdf(String docxFilePath, String pdfFilePath, Map<String, Map<String, Object>> params) throws Exception {
        try {

            File docxFile = new File(docxFilePath);
            File pdfFile = new File(pdfFilePath);
            //转换pdf文件
            if (docxFile.exists()) {
                if (!pdfFile.exists()) {
                    InputStream inStream = new FileInputStream(docxFilePath);
                    XWPFDocument document = new XWPFDocument(inStream);
                    //赋值word
                    //replaceInPara(document, params.get("content"));
                    //wordToolService.changeTableText(document, params.get("tabl"));
                    OutputStream os = new FileOutputStream(docxFilePath);
                    document.write(os);
                    os = null;
                    os = new FileOutputStream(pdfFilePath);
                    PdfOptions options = PdfOptions.create();
                    PdfConverter.getInstance().convert(document, os, options);
                    //关闭流
                    //  this.close(os);
                    //  this.close(inStream);
                }
            }
        } catch (IOException e) {
            int ddd;
            //   br.close();
        }
    }





<!--
        <dependency>
            <groupId>org.apache.poi</groupId>
            <artifactId>poi-ooxml</artifactId>
            <version>3.10.1</version>
        </dependency>
        <dependency>
            <groupId>org.apache.poi</groupId>
            <artifactId>poi-scratchpad</artifactId>
            <version>3.10.1</version>
        </dependency>
         https://mvnrepository.com/artifact/fr.opensagres.xdocreport/xdocreport -->
        <dependency>
            <groupId>fr.opensagres.xdocreport</groupId>
            <artifactId>xdocreport</artifactId>
            <version>2.0.1</version>
        </dependency>
        <!-- https://mvnrepository.com/artifact/fr.opensagres.xdocreport/fr.opensagres.xdocreport.converter.docx.xwpf -->
        <dependency>
            <groupId>fr.opensagres.xdocreport</groupId>
            <artifactId>fr.opensagres.xdocreport.converter.docx.xwpf</artifactId>
            <version>2.0.2</version>
        </dependency>
-->
    private static void test1DocToPDF(String argSource, String argDes) throws IOException, SAXException, TransformerException {
        String stringFopath = "D:/contract/contract1.fo";
        WordToFoConverter.main(new String[]{argSource, stringFopath});
        //changeContent(stringFopath, params);


        FopFactory fopFactory = FopFactory.newInstance(new File("D:/contract/fonts/fo.config.xml"));


        try (OutputStream out = new BufferedOutputStream(new FileOutputStream(new File(argDes)))) {
            // Step 3: Construct fop with desired output format
            Fop fop = fopFactory.newFop(MimeConstants.MIME_PDF, out);

            // Step 4: Setup JAXP using identity transformer
            TransformerFactory factory = TransformerFactory.newInstance();
            Transformer transformer = factory.newTransformer(); // identity transformer

            // Step 5: Setup input and output for XSLT transformation
            // Setup input stream
            Source src = new StreamSource(new File("D:/contract/contract1.fo"));

            // Resulting SAX events (the generated FO) must be piped through to FOP
            Result res = new SAXResult(fop.getDefaultHandler());

            // Step 6: Start XSLT transformation and FOP processing
            transformer.transform(src, res);

        }
    }
*/
}
